using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Interfaces
{
    public interface IPermissionAdminCategoryService
    {
        Task<IEnumerable<PermissionAdminCategoryViewModel>> GetMany();
    }
}