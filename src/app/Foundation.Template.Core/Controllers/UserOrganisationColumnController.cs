using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.API.Controllers
{
    [Route("api/core/v1")]
    public class UserOrganisationColumnController : ControllerBase
    {
        private readonly IUserOrganisationColumnService _userOrganisationColumnService;

        public UserOrganisationColumnController(IUserOrganisationColumnService userOrganisationColumnService)
        {
            _userOrganisationColumnService = userOrganisationColumnService;
        }

        [HttpPost("organisation-types/{organisationTypeId:Guid}/tables/{tableId}")]
        public async Task<ActionResult> Update([FromBody] UpdateUserOrganisationColumnViewModel payload)
        {
            await _userOrganisationColumnService.Update(payload);
            return Ok();
        }


        [HttpGet("userOrganisationColumns")]
        public async Task<ActionResult<IEnumerable<UserOrganisationColumnInfosViewModel>>> GetMany([FromQuery] UserOrganisationColumnFilterViewModel filter)
        {
            var result = await _userOrganisationColumnService.GetMany(filter);
            return Ok(result);
        }
    }
}
