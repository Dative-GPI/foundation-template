using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Interfaces;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionCategoriesController : ControllerBase
    {
        private readonly IPermissionCategoryService _permissionCategoryService;

        public PermissionCategoriesController(IPermissionCategoryService permissionCategoryService)
        {
            _permissionCategoryService = permissionCategoryService;
        }

        [Route("permission-categories")]
        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var result = await _permissionCategoryService.GetMany();
            return Ok(result);
        }
    }
}