using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Foundation.Template.Proxy.Extensions;
using Foundation.Template.Proxy.Tools;

namespace Foundation.Template.Proxy.Controllers
{
    [Route("api/admin/v1")]
    public class AdminActionsController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        private string _foundationPrefix;
        private LocalClient _localClient;
        private string _localPrefix;

        public AdminActionsController(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            LocalClient localClient)
        {
            _httpClientFactory = httpClientFactory;
            _foundationPrefix = configuration.GetConnectionString("Foundation");
            _localPrefix = configuration.GetConnectionString("Local");
            _localClient = localClient;
        }


        [HttpGet("actions")]
        public async Task<IActionResult> GetMany()
        {
            var foundationClient = _httpClientFactory.CreateClient();
            var foundationResponse = await foundationClient.GetAsync(HttpContext, _foundationPrefix);
            var foundationContent = await foundationResponse.Content.ReadAsStringAsync();
            var foundationResult = JsonSerializer.Deserialize<List<JsonElement>>(foundationContent);

            var localResult = await _localClient.Get<List<JsonElement>>(HttpContext, "/api/admin/actions");

            var result = new List<JsonElement>();

            result.AddRange(foundationResult);
            result.AddRange(localResult.Select(l => JsonSerializer.SerializeToElement(new
            {
                extensionId = (Guid?)null,
                actionType = l.GetProperty("actionType").GetInt32(),
                path = l.GetProperty("path").GetString(),
                label = l.GetProperty("label").GetString(),
                icon = l.GetProperty("icon").GetString(),
                uri = new UriBuilder("https", new Uri(_localPrefix).Host)
            })));

            return Ok(result);
        }
    }
}