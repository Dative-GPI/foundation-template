using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IUserOrganisationColumnService
    {
        Task<IEnumerable<UserOrganisationColumnInfosViewModel>> GetMany(UserOrganisationColumnFilterViewModel filter);
        Task Update(UpdateUserOrganisationColumnViewModel payload);
    }
}