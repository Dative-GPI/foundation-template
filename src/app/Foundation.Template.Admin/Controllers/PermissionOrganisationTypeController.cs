using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionOrganisationTypeController : ControllerBase
    {
        private readonly IPermissionOrganisationTypeService _permissionOrganisationTypeService;

        public PermissionOrganisationTypeController(IPermissionOrganisationTypeService permissionOrganisationTypeService)
        {
            _permissionOrganisationTypeService = permissionOrganisationTypeService;
        }
        
        [Route("organisation-types-permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] PermissionOrganisationTypesFilterViewModel filter)
        {
            var result = await _permissionOrganisationTypeService.GetMany(filter);
            return Ok(result);
        }

        [Route("organisation-types-permissions")]
        [HttpPatch]
        public async Task<IActionResult> Upsert([FromBody] List<UpsertPermissionOrganisationTypesViewModel> payload)
        {
            await _permissionOrganisationTypeService.Upsert(payload);
            return Ok();
        }
    }
}