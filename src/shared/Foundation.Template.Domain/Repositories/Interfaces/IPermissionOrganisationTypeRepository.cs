using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IPermissionOrganisationTypeRepository
    {
        Task<IEnumerable<PermissionOrganisationTypeInfos>> GetMany(PermissionOrganisationTypesFilter filter);
        Task CreateRange(IEnumerable<CreatePermissionOrganisationType> payload);
        Task RemoveRange(Guid[] permissionsIds);
    }
}