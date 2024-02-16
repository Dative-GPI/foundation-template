using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IOrganisationTypeTableService
    {
        Task<OrganisationTypeTableDetailsViewModel> Get(Guid organisationTypeId, Guid tableId);
        Task<OrganisationTypeTableDetailsViewModel> Update(Guid organisationTypeId, Guid tableId, UpdateOrganisationTypeTableViewModel payload);
    }
}