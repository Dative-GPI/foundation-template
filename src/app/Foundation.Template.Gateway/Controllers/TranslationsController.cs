using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Foundation.Template.Gateway.Abstractions;
using Foundation.Template.Gateway.ViewModels;

namespace Foundation.Template.Gateway.Controllers
{
    public class ApplicationTranslationsController : ControllerBase
    {
        private IApplicationTranslationService _applicationTranslationService;

        public ApplicationTranslationsController(IApplicationTranslationService applicationTranslationService)
        {
            _applicationTranslationService = applicationTranslationService;
        }

        [HttpGet("api/translations")]
        [HttpGet("api/gateway/v1/translations")]
        public async Task<IActionResult> GetMany()
        {
            var translations = await _applicationTranslationService.GetMany();
            return Ok(translations);
        }
    }
}
