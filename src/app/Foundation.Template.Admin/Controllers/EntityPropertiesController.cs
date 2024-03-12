using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;
using System.Collections.Generic;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class EntityPropertiesController : ControllerBase
    {
        private readonly IEntityPropertyService _entityPropertyService;

        public EntityPropertiesController(IEntityPropertyService entityPropertyService)
        {
            _entityPropertyService = entityPropertyService;
        }

        [Route("entity-properties")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityPropertyViewModel>>> GetMany([FromQuery] EntityPropertiesFilterViewModel filter)
        {
            var result = await _entityPropertyService.GetMany(filter);
            return Ok(result);
        }
    }
}
