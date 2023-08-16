using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Shell.Interfaces;

namespace Foundation.Template.Shell.Controllers
{
    [Route("api/v1")]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [Route("organisations/{organisationId:Guid}/permissions/current")]
        [HttpGet]
        public async Task<IActionResult> GetCurrent()
        {
            var result = await _permissionService.GetCurrent();
            return Ok(result);
        }


        [Route("organisations/{organisationId:Guid}/permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var result = await _permissionService.GetMany();
            return Ok(result);
        }


        [Route("organisations/{organisationId:Guid}/permissions/categories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _permissionService.GetCategories();
            return Ok(result);
        }
    }
}