using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/routes")]
    public class RoutesController : ControllerBase
    {
        private IRouteService _routeService;

        public RoutesController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var routes = await _routeService.GetMany();
            return Ok(routes);
        }
    }
}
