using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [Route("permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] PermissionsFilterViewModel filter)
        {
            var result = await _permissionService.GetMany(filter);
            return Ok(result);
        }
    }
}