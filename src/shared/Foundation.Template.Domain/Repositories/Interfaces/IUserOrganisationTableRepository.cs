using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IUserOrganisationTableRepository
    {
        Task<IEntity<Guid>> Update(UpdateUserOrganisationTable filter);
        Task<UserOrganisationTable> Get(Guid id);
        Task<IEnumerable<UserOrganisationTable>> GetMany(UserOrganisationTableFilter filter);
        Task<IEntity<Guid>> Create(CreateUserOrganisationTable payload);
        Task Remove(Guid userOrganisationColumnId);
    }
}