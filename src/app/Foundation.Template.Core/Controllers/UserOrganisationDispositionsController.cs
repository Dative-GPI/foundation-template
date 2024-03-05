using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.API.Controllers
{
    [Route("api/core/v1")]
    public class UserOrganisationDispositionsController : ControllerBase
    {
        private readonly IUserOrganisationDispositionService _userOrganisationDispositionService;
        public UserOrganisationDispositionsController(IUserOrganisationDispositionService userOrganisationDispositionService)
        {
            _userOrganisationDispositionService = userOrganisationDispositionService;
        }

        [HttpGet("tables/{tableCode}/dispositions")]
        public async Task<ActionResult<UserOrganisationDispositionViewModel>> GetMany([FromRoute] string tableCode)
        {
            var result = await _userOrganisationDispositionService.GetMany(tableCode);
            return Ok(result);
        }

        [HttpPost("tables/{tableCode}/dispositions")]
        public async Task<OkResult> Update([FromRoute] string tableCode, [FromBody] UpdateUserOrganisationDispositionViewModel payload)
        {
            await _userOrganisationDispositionService.Update(tableCode, payload);
            return Ok();
        }
    }
}
