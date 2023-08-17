using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Foundation.Template.Proxy.Extensions;

namespace Foundation.Template.Proxy.Controllers
{
    [Route("api/admin/v1")]
    public class ExtensionsController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        private string _foundationPrefix;

        public ExtensionsController(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _foundationPrefix = configuration.GetConnectionString("Foundation");
        }


        [HttpGet("extensions")]
        public async Task<IActionResult> GetMany()
        {
            var foundationClient = _httpClientFactory.CreateClient();
            var foundationResponse = await foundationClient.SendAsync(HttpContext, _foundationPrefix);

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
    }
}