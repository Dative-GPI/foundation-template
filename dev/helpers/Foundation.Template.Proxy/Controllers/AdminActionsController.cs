using System;
using System.Linq;
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
    public class AdminActionsController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        private string _foundationPrefix;
        private string _localPrefix;

        public AdminActionsController(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _foundationPrefix = configuration.GetConnectionString("Foundation");
            _localPrefix = configuration.GetConnectionString("Local");
        }


        [HttpGet("actions")]
        public async Task<IActionResult> GetMany()
        {
            var foundationClient = _httpClientFactory.CreateClient();
            var foundationResponse = await foundationClient.SendAsync(HttpContext, _foundationPrefix);

            var localClient = _httpClientFactory.CreateClient();
            var localReponse = await localClient.SendAsync(HttpContext, _localPrefix, "/api/admin/actions");

            var foundationContent = await foundationResponse.Content.ReadAsStringAsync();
            var localContent = await localReponse.Content.ReadAsStringAsync();

            var foundationResult = JsonSerializer.Deserialize<List<JsonElement>>(foundationContent);
            var localResult = JsonSerializer.Deserialize<List<JsonElement>>(localContent);

            var result = new List<JsonElement>();

            result.AddRange(foundationResult);
            result.AddRange(localResult.Select(l => JsonSerializer.SerializeToElement(new
            {
                extensionId = (Guid?)null,
                
                uri = _localPrefix
            })));

            return Ok(result);
        }
    }
}