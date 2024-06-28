using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bones.Repository.Interfaces;
using Foundation.Extension.Domain.Models;
using Foundation.Extension.Domain.Repositories.Commands;
using Foundation.Extension.Domain.Repositories.Filters;

namespace Foundation.Extension.Domain.Repositories.Interfaces
{
    public interface IUserOrganisationTableRepository
    {
        Task<IEntity<Guid>> Update(UpdateUserOrganisationTable filter);
        Task<UserOrganisationTable> Get(Guid id);
        Task<IEnumerable<UserOrganisationTable>> GetMany(UserOrganisationTablesFilter filter);
        Task<IEntity<Guid>> Create(CreateUserOrganisationTable payload);
        Task Remove(Guid userOrganisationColumnId);
    }
}