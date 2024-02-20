using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IRolePermissionOrganisationService
    {
        Task<RolePermissionOrganisationDetailsViewModel> Get(Guid id);
        Task<RolePermissionOrganisationDetailsViewModel> Update(Guid id, UpdateRolePermissionOrganisationViewModel payload);
    }
}