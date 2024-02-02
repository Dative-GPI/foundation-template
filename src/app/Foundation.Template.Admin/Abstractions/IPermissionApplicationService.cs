using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IPermissionApplicationService
    {
        Task<IEnumerable<PermissionApplicationInfosViewModel>> GetMany(PermissionApplicationFilterViewModel filter);
        Task<IEnumerable<string>> GetCurrent();
    }
}
