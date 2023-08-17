using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class TranslationsController : ControllerBase
    {
        private ITranslationService _translationService;

        public TranslationsController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet("translations")]
        public async Task<IActionResult> GetMany()
        {
            var translations = await _translationService.GetMany();
            return Ok(translations);
        }
    }
}
