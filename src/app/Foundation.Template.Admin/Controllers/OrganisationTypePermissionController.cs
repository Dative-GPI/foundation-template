using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class OrganisationTypePermissionController : ControllerBase
    {
        private readonly IOrganisationTypePermissionOrganisationService _organisationTypePermissionService;

        public OrganisationTypePermissionController(IOrganisationTypePermissionOrganisationService organisationTypePermissionService)
        {
            _organisationTypePermissionService = organisationTypePermissionService;
        }
        
        [Route("organisation-types-permissions")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] OrganisationTypePermissionsFilterViewModel filter)
        {
            var result = await _organisationTypePermissionService.GetMany(filter);
            return Ok(result);
        }

        [Route("organisation-types-permissions")]
        [HttpPatch]
        public async Task<IActionResult> Upsert([FromBody] List<UpsertOrganisationTypePermissionsViewModel> payload)
        {
            await _organisationTypePermissionService.Upsert(payload);
            return Ok();
        }
    }
}