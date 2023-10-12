using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Foundation.Template.Proxy.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Foundation.Template.Proxy.Controllers
{
    [Route("api/admin/v1")]
    public class AdminExtensionsController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        private string _foundationPrefix;
        private string _hostLocal;

        public AdminExtensionsController(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _foundationPrefix = configuration.GetConnectionString("Foundation");
            _hostLocal = configuration.GetConnectionString("Local");
        }


        [HttpGet("extensions")]
        public async Task<IActionResult> GetMany()
        {
            var foundationClient = _httpClientFactory.CreateClient();
            var foundationResponse = await foundationClient.GetAsync(HttpContext, _foundationPrefix);

            var content = await foundationResponse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<JsonElement>>(content);

            result.Add(JsonSerializer.SerializeToElement(new
            {
                id = (Guid?)null,
                @public = false,
                label = "Local extension",
                description = "Added automatically by Foundation.Template.Proxy",
                translations = new List<JsonElement>()
            }));

            return Ok(result);
        }


        [HttpGet("extensions/null")]
        public IActionResult GetRoleExtension()
        {
            return Ok(new
            {
                id = (Guid?)null,
                extensionId = (Guid?)null,
                shellHost = new Uri(_hostLocal).Host,
                adminHost = new Uri(_hostLocal).Host,
                host = new Uri(_hostLocal).Host,
                label = "Local extension",
                description = "Added automatically by Foundation.Template.Proxy"
            });
        }
    }
}