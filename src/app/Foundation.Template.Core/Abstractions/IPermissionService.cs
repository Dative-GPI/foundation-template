using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IPermissionService
    {
        Task<IEnumerable<string>> GetCurrent();
        Task<IEnumerable<PermissionInfosViewModel>> GetMany();
        Task<IEnumerable<PermissionCategoryViewModel>> GetCategories();
    }
}