using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class RolePermissionOrganisationsController : ControllerBase
    {
        private readonly IRolePermissionOrganisationService _roleOrganisationService;

        public RolePermissionOrganisationsController(IRolePermissionOrganisationService roleOrganisationService)
        {
            _roleOrganisationService = roleOrganisationService;
        }
        
        [Route("role-organisations/{roleId:Guid}")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid roleId)
        {
            var result = await _roleOrganisationService.Get(roleId);
            return Ok(result);
        }

        [Route("role-organisations/{roleId:Guid}")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] Guid roleId, [FromBody] UpdateRolePermissionOrganisationViewModel payload)
        {
            var result = await _roleOrganisationService.Update(roleId, payload);
            return Ok(result);
        }
    }
}