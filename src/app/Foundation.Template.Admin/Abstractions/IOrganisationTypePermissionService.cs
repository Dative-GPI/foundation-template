using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IOrganisationTypePermissionService
    {
        Task<IEnumerable<OrganisationTypePermissionInfosViewModel>> GetMany(OrganisationTypePermissionsFilterViewModel filter);
        Task Upsert(List<UpsertOrganisationTypePermissionsViewModel> payload);
    }
}