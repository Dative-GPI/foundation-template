using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Foundation.Template.Admin.Interfaces;

namespace Foundation.Template.Admin.Controllers
{
    [Route("api/admin/v1")]
    public class PermissionAdminCategoriesController : ControllerBase
    {
        private readonly IPermissionAdminCategoryService _permissionAdminCategoryService;

        public PermissionAdminCategoriesController(IPermissionAdminCategoryService permissionAdminCategoryService)
        {
            _permissionAdminCategoryService = permissionAdminCategoryService;
        }

        [Route("permission-admin-categories")]
        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var result = await _permissionAdminCategoryService.GetMany();
            return Ok(result);
        }
    }
}