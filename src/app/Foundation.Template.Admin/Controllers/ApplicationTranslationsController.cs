using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class ApplicationTranslationsController : ControllerBase
    {
        private IApplicationTranslationService _applicationTranslationService;

        public ApplicationTranslationsController(IApplicationTranslationService applicationTranslationService)
        {
            _applicationTranslationService = applicationTranslationService;
        }

        [HttpGet("application-translations")]
        public async Task<IActionResult> GetMany()
        {
            var translations = await _applicationTranslationService.GetMany();
            return Ok(translations);
        }

        [HttpPost("application-translations")]
        public async Task<IActionResult> UpdateRange([FromBody]IEnumerable<UpdateApplicationTranslationViewModel> payload)
        {
            await _applicationTranslationService.UpdateRange(payload);
            return Ok();
        }
    }
}
