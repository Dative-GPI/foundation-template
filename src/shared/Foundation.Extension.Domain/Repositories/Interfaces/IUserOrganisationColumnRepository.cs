using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation.Extension.Domain.Models;
using Foundation.Extension.Domain.Repositories.Commands;
using Foundation.Extension.Domain.Repositories.Filters;

namespace Foundation.Extension.Domain.Repositories.Interfaces
{
    public interface IUserOrganisationColumnRepository
    {
        Task<IEnumerable<UserOrganisationColumn>> GetMany(UserOrganisationColumnsFilter filter);
        Task Create(CreateUserOrganisationColumn payload);
        Task CreateMany(IEnumerable<CreateUserOrganisationColumn> payload);
        Task Remove(Guid userOrganisationColumnId);
        Task RemoveMany(IEnumerable<Guid> userOrganisationColumnsIds);
    }
}