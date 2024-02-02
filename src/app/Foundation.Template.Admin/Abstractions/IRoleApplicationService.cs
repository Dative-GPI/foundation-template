using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IRoleApplicationService
    {
        Task<RoleApplicationDetailsViewModel> Get(Guid id);
        Task<RoleApplicationDetailsViewModel> Update(Guid id, UpdateRoleApplicationViewModel payload);
    }
}