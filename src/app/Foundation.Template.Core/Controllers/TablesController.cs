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
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("tables/{tableCode}/dispositions")]
        public async Task<ActionResult<TableViewModel>> GetMany([FromRoute] string tableCode)
        {
            var result = await _tableService.GetMany(tableCode);
            return Ok(result);
        }

        [HttpPost("tables/{tableCode}/dispositions")]
        public async Task<OkResult> Update([FromRoute] string tableCode, [FromBody] UpdateTableViewModel payload)
        {
            await _tableService.Update(tableCode, payload);
            return Ok();
        }
    }
}
