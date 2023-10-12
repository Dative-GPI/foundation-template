using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IOrganisationTypePermissionOrganisationService
    {
        Task<IEnumerable<OrganisationTypePermissionOrganisationInfosViewModel>> GetMany(OrganisationTypePermissionsFilterViewModel filter);
        Task Upsert(List<UpsertOrganisationTypePermissionsViewModel> payload);
    }
}