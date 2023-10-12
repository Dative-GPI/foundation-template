using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IPermissionOrganisationCategoryService
    {
        Task<IEnumerable<PermissionOrganisationCategoryViewModel>> GetMany();
    }
}