using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

using Foundation.Template.Domain.Abstractions;

namespace Foundation.Template.Gateway.Middlewares
{
    public class JWTAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private IServiceProvider _serviceProvider;
        private HttpClient _httpClient;
        private ILogger<JWTAuthenticationMiddleware> _logger;

        public JWTAuthenticationMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<JWTAuthenticationMiddleware> logger, HttpClient httpClient)
        {
            _next = next;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogTrace("Invoked");

            if (context.Features.Get<IEndpointFeature>().Endpoint.Metadata.Any(m => m is AllowAnonymousAttribute))
            {
                _logger.LogTrace("Anonymous request");
                await _next(context);
            }
            else
            {
                using var scope = _serviceProvider.CreateScope();
                var sp = scope.ServiceProvider;

                var bearer = context.Request.Headers[HeaderNames.Authorization];

                if (String.IsNullOrWhiteSpace(bearer))
                {
                    Unauthorized(context);
                    return;
                }

                var toRead = bearer.ToString().Substring("Bearer ".Length);
                var token = new JwtSecurityTokenHandler().ReadJwtToken(toRead);
                var claimsFactory = sp.GetRequiredService<IClaimsFactory>();

                var claims = claimsFactory.Get(token.Claims);

                var clientFactory = sp.GetRequiredService<IFoundationClientFactory>();

                var client = await clientFactory.CreateAuthenticated(claims.ApplicationId, claims.LanguageCode, toRead);

                var isAuthenticated = await client.Gateway.Accounts.IsAuthenticated();

                if (isAuthenticated)
                {
                    _logger.LogTrace("Authentication succeed");

                    ClaimsIdentity identity = new ClaimsIdentity(token.Claims, "Custom");

                    context.User = new ClaimsPrincipal(identity);
                    await _next(context);
                }
                else
                {
                    _logger.LogInformation("Unable to authenticate current request : User {user} - Source {source}", claims.UserId, claims.SourceId);
                    Unauthorized(context);
                    return;
                }
            }
        }

        private void Unauthorized(HttpContext context)
        {
            context.Response.StatusCode = 401;
        }
    }
}