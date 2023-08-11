using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class RoleAdminsController : ControllerBase
    {
        private readonly IRoleAdminService _roleAdminService;

        public RoleAdminsController(IRoleAdminService roleAdminService)
        {
            _roleAdminService = roleAdminService;
        }
        
        [Route("role-admins/{id:Guid}")]
        [HttpGet]
        public async Task<IActionResult> GetMany([FromRoute] Guid id)
        {
            var result = await _roleAdminService.Get(id);
            return Ok(result);
        }

        [Route("role-admins/{id:Guid}")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRoleAdminViewModel payload)
        {
            var result = await _roleAdminService.Update(id, payload);
            return Ok(result);
        }
    }
}