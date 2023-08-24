using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IRoleOrganisationService
    {
        Task<RoleOrganisationDetailsViewModel> Get(Guid roleId);
        Task<RoleOrganisationDetailsViewModel> Update(Guid id, UpdateRoleOrganisationViewModel payload);
    }
}