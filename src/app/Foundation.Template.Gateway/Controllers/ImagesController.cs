using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Gateway.Abstractions;
using Foundation.Template.Gateway.ViewModels;

namespace Foundation.Template.Gateway.Controllers
{
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageFileService;

        public ImagesController(IImageService imageFileService)
        {
            _imageFileService = imageFileService;
        }

        [ResponseCache(Duration = 3600)]
        [HttpGet("api/v1/images/raw/{id:Guid}")] // keep for backward compatibility
        [HttpGet("api/gateway/v1/raw-images/{id:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRaw([FromRoute] Guid id)
        {
            var result = await _imageFileService.GetRaw(id);
            return File(result, "image/png");
        }

        [ResponseCache(Duration = 3600)]
        [HttpGet("api/v1/images/thumbnail/{id:Guid}")] // keep for backward compatibility
        [HttpGet("api/gateway/v1/images/thumbnail/{id:Guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetThumbnail([FromRoute] Guid id)
        {
            var result = await _imageFileService.GetThumbnail(id);
            return File(result, "image/png");
        }
    }
}
