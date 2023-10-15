using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Core.Abstractions;

namespace Foundation.Template.Core.Controllers
{
    [Route("api/core/v1")]
    public class PermissionOrganisationsController : ControllerBase
    {
        private readonly IPermissionOrganisationService _permissionService;

        public PermissionOrganisationsController(IPermissionOrganisationService permissionService)
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