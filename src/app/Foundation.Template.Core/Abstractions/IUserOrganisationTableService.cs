using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IUserOrganisationTableService
    {
        Task<UserOrganisationTableDetailsViewModel> Get(Guid userOrganisationTableId);
        Task<IEnumerable<UserOrganisationTableInfosViewModel>> GetMany(UserOrganisationTableFilterViewModel filter);
        Task Update(Guid tableId, UpdateUserOrganisationTableViewModel payload);
    }
}