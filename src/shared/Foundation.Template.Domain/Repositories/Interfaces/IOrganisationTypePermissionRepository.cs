using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IOrganisationTypePermissionRepository
    {
        Task<IEnumerable<OrganisationTypePermissionOrganisationInfos>> GetMany(OrganisationTypePermissionsFilter filter);
        Task CreateRange(IEnumerable<CreateOrganisationTypePermission> payload);
        Task RemoveRange(Guid[] permissionsIds);
    }
}