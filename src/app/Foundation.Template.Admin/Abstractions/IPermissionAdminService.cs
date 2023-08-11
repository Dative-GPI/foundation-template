using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Interfaces
{
    public interface IPermissionAdminService
    {
        Task<IEnumerable<PermissionAdminInfosViewModel>> GetMany(PermissionAdminFilterViewModel filter);
        Task<IEnumerable<string>> GetCurrent();
    }
}
