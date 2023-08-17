using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Shell.Abstractions;
using Foundation.Template.Shell.ViewModels;

namespace Foundation.Template.Shell.Controllers
{
    [Route("api")]
    public class ActionsController : ControllerBase
    {
        private IActionService _actionService;

        public ActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet("organisations/{organisationId:Guid}/actions")]
        public async Task<IActionResult> GetMany(Guid organisationId, [FromQuery] ActionsFilterViewModel filter)
        {
            var actions = await _actionService.GetMany(filter);
            return Ok(actions);
        }
    }
}