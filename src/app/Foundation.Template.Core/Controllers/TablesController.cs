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

        [HttpGet("tables/{tableId:Guid}")]
        public async Task<ActionResult<ApplicationTableDetailsViewModel>> Get([FromRoute] Guid tableId)
        {
            var result = await _tableService.Get(tableId);
            return Ok(result);
        }
    }
}
