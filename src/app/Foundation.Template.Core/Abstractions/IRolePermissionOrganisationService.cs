using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IRolePermissionOrganisationService
    {
        Task<RolePermissionOrganisationDetailsViewModel> Get(Guid roleId);
        Task<RolePermissionOrganisationDetailsViewModel> Update(Guid id, UpdateRolePermissionOrganisationViewModel payload);
    }
}