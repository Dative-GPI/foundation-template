using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Shell.ViewModels;

namespace Foundation.Template.Shell.Abstractions
{
    public interface IRoleOrganisationService
    {
        Task<RoleOrganisationDetailsViewModel> Get(Guid roleId);
        Task<RoleOrganisationDetailsViewModel> Update(Guid id, UpdateRoleOrganisationViewModel payload);
    }
}