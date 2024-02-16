using System;
using System.Threading.Tasks;
using Foundation.Template.Admin.Models;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IOrganisationTypeTableProvider
    {
        Task<OrganisationTypeTableDetails> Get(Guid organisationTypeId, Guid tableId);
    }
}