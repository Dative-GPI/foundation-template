using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Shell.ViewModels;

namespace Foundation.Template.Shell.Abstractions
{
    public interface IPermissionService
    {
        Task<IEnumerable<string>> GetCurrent();
        Task<IEnumerable<PermissionInfosViewModel>> GetMany();
        Task<IEnumerable<PermissionCategoryViewModel>> GetCategories();
    }
}