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
    public class ShellActionsController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory;
        private string _foundationPrefix;
        private string _localPrefix;

        public ShellActionsController(
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
            // TODO : récupérer dans l'url quand on fera la mise à jour
            Guid organisationId = HttpContext.Request.Headers.TryGetValue("X-Organisation-Id", out var organisationIdHeader)
                ? Guid.Parse(organisationIdHeader)
                : Guid.Empty;

            var foundationClient = _httpClientFactory.CreateClient();
            var foundationResponse = await foundationClient.SendAsync(HttpContext, _foundationPrefix);

            var localClient = _httpClientFactory.CreateClient();
            var localReponse = await localClient.SendAsync(HttpContext, _localPrefix, "/api/organisations/" + organisationId + "/actions");

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