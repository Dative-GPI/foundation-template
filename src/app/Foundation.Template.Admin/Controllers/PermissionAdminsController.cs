using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionAdminsController : ControllerBase
    {
        private readonly IPermissionAdminService _permissionAdminService;

        public PermissionAdminsController(IPermissionAdminService permissionAdminService)
        {
            _permissionAdminService = permissionAdminService;
        }

        [Route("permission-admins")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] PermissionAdminFilterViewModel filter)
        {
            var result = await _permissionAdminService.GetMany(filter);
            return Ok(result);
        }

        [Route("permission-admins/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent()
        {
            var result = await _permissionAdminService.GetCurrent();
            return Ok(result);
        }
    }
}