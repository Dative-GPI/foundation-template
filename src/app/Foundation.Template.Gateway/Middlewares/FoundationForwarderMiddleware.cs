using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;

using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Forwarder;

using Foundation.Template.Domain.Abstractions;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Gateway.Middlewares
{
    public class FoundationForwarderMiddleware
    {
        private ILogger<FoundationForwarderMiddleware> _logger;
        private IHttpForwarder _forwarder;
        private HttpMessageInvoker _httpClient;
        private readonly IMemoryCache _memoryCache;

        static MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5));

        public FoundationForwarderMiddleware(
            ILogger<FoundationForwarderMiddleware> logger,
            IHttpForwarder forwarder,
            IForwarderHttpClientFactory httpClientFactory,
            IMemoryCache memoryCache)
        {
            _logger = logger;
            _forwarder = forwarder;
            _httpClient = httpClientFactory.CreateClient(new ForwarderHttpClientContext()
            {
                NewConfig = HttpClientConfig.Empty
            });
            _memoryCache = memoryCache;
        }

        public async Task Forward(HttpContext httpContext)
        {
            using var scope = httpContext.RequestServices.CreateScope();

            var sp = scope.ServiceProvider;

            var bearer = httpContext.Request.Headers[HeaderNames.Authorization];

            if (String.IsNullOrWhiteSpace(bearer))
            {
                _logger.LogWarning("No bearer token found, can't find the application to forward the request to.");
                httpContext.Response.StatusCode = 401;
                return;
            }

            var toRead = bearer.ToString().Substring("Bearer ".Length);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(toRead);
            var claimsFactory = sp.GetRequiredService<IClaimsFactory>();

            var claims = claimsFactory.Get(token.Claims);

            if (!_memoryCache.TryGetValue(claims.ApplicationId, out string host))
            {
                var applicationRepository = httpContext.RequestServices.GetRequiredService<IApplicationRepository>();
                var application = await applicationRepository.Get(claims.ApplicationId);

                if (application == null)
                {
                    _logger.LogWarning("No application found with id {0}, can't forward the request.", claims.ApplicationId);
                    httpContext.Response.StatusCode = 400;
                    return;
                }

                host = application.ShellHost;

                _memoryCache.Set(claims.ApplicationId, host, _cacheEntryOptions);
            }

            await _forwarder.SendAsync(httpContext, host, _httpClient);
        }
    }
}