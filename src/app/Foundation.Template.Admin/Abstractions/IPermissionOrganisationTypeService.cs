using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IPermissionOrganisationTypeService
    {
        Task<IEnumerable<PermissionOrganisationTypeInfosViewModel>> GetMany(PermissionOrganisationTypesFilterViewModel filter);
        Task Upsert(List<UpsertPermissionOrganisationTypesViewModel> payload);
    }
}