using System;
using System.Threading.Tasks;
using Foundation.Template.Core.Models;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Core.Abstractions
{
    public interface IOrganisationTypeTableProvider
    {
        Task<OrganisationTypeTableDetails> Get(Guid organisationTypeId, Guid tableId);
    }
}