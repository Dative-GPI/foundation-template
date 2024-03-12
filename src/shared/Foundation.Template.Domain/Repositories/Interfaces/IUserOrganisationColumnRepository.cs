using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
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