using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Foundation.Template.Proxy.Extensions;
using System.Linq;

namespace Foundation.Template.Proxy.Controllers
{
    [Route("api/v1")]
    public class ShellRoutesController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        private string _foundationPrefix;
        private string _localPrefix;

        public ShellRoutesController(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _foundationPrefix = configuration.GetConnectionString("Foundation");
            _localPrefix = configuration.GetConnectionString("Local");
        }


        [HttpGet("routes")]
        public async Task<IActionResult> GetMany()
        {
            // TODO : récupérer dans l'url quand on fera la mise à jour
            Guid organisationId = HttpContext.Request.Headers.TryGetValue("X-Organisation-Id", out var organisationIdHeader)
                ? Guid.Parse(organisationIdHeader)
                : Guid.Empty;

            var foundationClient = _httpClientFactory.CreateClient();
            var foundationResponse = await foundationClient.SendAsync(HttpContext, _foundationPrefix);

            var localClient = _httpClientFactory.CreateClient();
            var localReponse = await localClient.SendAsync(HttpContext, _localPrefix, "/api/organisations/" + organisationId + "/routes");

            var foundationContent = await foundationResponse.Content.ReadAsStringAsync();
            var localContent = await localReponse.Content.ReadAsStringAsync();

            var foundationResult = JsonSerializer.Deserialize<List<JsonElement>>(foundationContent);
            var localResult = JsonSerializer.Deserialize<List<JsonElement>>(localContent);

            var result = new List<JsonElement>();

            result.AddRange(foundationResult);
            result.AddRange(localResult.Select(l => JsonSerializer.SerializeToElement(new
            {
                extensionId = (Guid?)null,
                drawerCategory = l.GetProperty("drawerCategory").GetString(),
                drawerIcon = l.GetProperty("drawerIcon").GetString(),
                drawerLabel = l.GetProperty("drawerLabel").GetString(),
                exact = l.GetProperty("exact").GetBoolean(),
                name = l.GetProperty("name").GetString(),
                path = l.GetProperty("path").GetString(),
                showOnDrawer = l.GetProperty("showOnDrawer").GetBoolean(),
                uri = _localPrefix
            })));

            return Ok(result);
        }
    }
}