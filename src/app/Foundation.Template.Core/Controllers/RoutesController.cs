using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Core.ViewModels;
using Foundation.Template.Core.Abstractions;

namespace Foundation.Template.Core.Controllers
{
    [Route("api/v1")]
    public class RoutesController : ControllerBase
    {
        private IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("organisations/{organisationId:Guid}/routes")]
        public async Task<IActionResult> GetMany()
        {
            var routes = await _routeService.GetMany();
            return Ok(routes);
        }
    }
}
