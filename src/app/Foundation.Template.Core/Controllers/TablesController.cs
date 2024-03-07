using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.API.Controllers
{
    [Route("api/core/v1")]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _TableService;
        public TablesController(ITableService TableService)
        {
            _TableService = TableService;
        }

        [HttpGet("tables/{tableCode}/dispositions")]
        public async Task<ActionResult<TableViewModel>> GetMany([FromRoute] string tableCode)
        {
            var result = await _TableService.GetMany(tableCode);
            return Ok(result);
        }

        [HttpPost("tables/{tableCode}/dispositions")]
        public async Task<OkResult> Update([FromRoute] string tableCode, [FromBody] UpdateTableViewModel payload)
        {
            await _TableService.Update(tableCode, payload);
            return Ok();
        }
    }
}
