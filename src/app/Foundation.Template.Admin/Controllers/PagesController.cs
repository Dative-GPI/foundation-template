using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1/pages")]
    public class PagesController : ControllerBase
    {
        private IPageService _pageService;

        public PagesController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var pages = await _pageService.GetMany();
            return Ok(pages);
        }
    }
}
