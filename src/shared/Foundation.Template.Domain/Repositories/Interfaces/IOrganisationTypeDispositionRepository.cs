using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IOrganisationTypeDispositionRepository
    {
        Task<IEnumerable<OrganisationTypeDisposition>> GetMany(ColumnOrganisationTypesFilter filter);
        Task Create(CreateOrganisationTypeDisposition payload);
        Task CreateMany(IEnumerable<CreateOrganisationTypeDisposition> payload);
        Task Remove(Guid organisationTypeDispositionId);
        Task RemoveMany(IEnumerable<Guid> organisationTypeDispositionsIds);
    }
}