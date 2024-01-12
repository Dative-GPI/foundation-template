using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> GetMany([FromQuery] TranslationsFilterViewModel filter)
        {
            var translations = await _applicationTranslationService.GetMany(filter);
            return Ok(translations);
        }

        [HttpPost("application-translations")]
        public async Task<IActionResult> UpdateRange([FromBody] IEnumerable<UpdateApplicationTranslationViewModel> payload)
        {
            await _applicationTranslationService.UpdateRange(payload);
            return Ok();
        }

        [HttpGet("application-translations/workbook")]
        public async Task<FileContentResult> Download([FromQuery] string fileName)
        {
            using (var stream = new MemoryStream())
            {
                await _applicationTranslationService.Download(stream);
                stream.Position = 0;

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        [HttpPut("application-translations/workbook")]
        public async Task<ActionResult<IEnumerable<ApplicationTranslationViewModel>>> Upload([FromForm] IEnumerable<ApplicationTranslationsColumnViewModel> languagesCodes, [FromForm] IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {

                var result = await _applicationTranslationService.Upload(languagesCodes, stream);
                return Ok(result);
            }
        }
    }
}
