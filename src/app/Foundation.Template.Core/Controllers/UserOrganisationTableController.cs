using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.API.Controllers
{
    [Route("api/core/v1")]
    public class UserOrganisationTableController : ControllerBase
    {
        private readonly IUserOrganisationTableService _userOrganisationTableService;

        public UserOrganisationTableController(IUserOrganisationTableService userOrganisationTableService)
        {
            _userOrganisationTableService = userOrganisationTableService;
        }

        [HttpGet("userOrganisationTables/{userOrganisationTableId:Guid}")]
        public async Task<ActionResult<UserOrganisationTableDetailsViewModel>> Get([FromRoute] Guid userOrganisationTableId)
        {
            var result = await _userOrganisationTableService.Get(userOrganisationTableId);
            return Ok(result);
        }

        [HttpPost("userOrganisationTables/{userOrganisationTableId:Guid}")]
        public async Task<OkResult> Update([FromRoute] Guid userOrganisationTableId, [FromBody] UpdateUserOrganisationTableViewModel payload)
        {
            await _userOrganisationTableService.Update(userOrganisationTableId, payload);
            return Ok();
        }


        [HttpGet("userOrganisationTables")]
        public async Task<ActionResult<IEnumerable<UserOrganisationTableInfosViewModel>>> GetMany([FromQuery] UserOrganisationTableFilterViewModel filter)
        {
            var result = await _userOrganisationTableService.GetMany(filter);
            return Ok(result);
        }
    }
}
