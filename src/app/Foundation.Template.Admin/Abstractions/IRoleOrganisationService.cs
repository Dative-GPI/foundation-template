using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Interfaces
{
    public interface IRoleOrganisationService
    {
        Task<RoleOrganisationDetailsViewModel> Get(Guid id);
        Task<RoleOrganisationDetailsViewModel> Update(Guid id, UpdateRoleOrganisationViewModel payload);
    }
}