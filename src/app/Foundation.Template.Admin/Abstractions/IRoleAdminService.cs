using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Interfaces
{
    public interface IRoleAdminService
    {
        Task<RoleAdminDetailsViewModel> Get(Guid id);
        Task<RoleAdminDetailsViewModel> Update(Guid id, UpdateRoleAdminViewModel payload);
    }
}