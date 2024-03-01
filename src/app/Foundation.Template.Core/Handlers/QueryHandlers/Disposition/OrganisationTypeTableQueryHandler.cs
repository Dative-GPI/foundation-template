using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Core.Abstractions;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Handlers
{
    public class OrganisationTypeTableQueryHandler : IMiddleware<OrganisationTypeTableQuery, OrganisationTypeTableDetails>
    {
        private IOrganisationTypeTableProvider _organisationTypeTableProvider;

        public OrganisationTypeTableQueryHandler(
            IOrganisationTypeTableProvider organisationTypeTableProvider)
        {
            _organisationTypeTableProvider = organisationTypeTableProvider;
        }

        public async Task<OrganisationTypeTableDetails> HandleAsync(OrganisationTypeTableQuery request, Func<Task<OrganisationTypeTableDetails>> next, CancellationToken cancellationToken)
        {
            return await _organisationTypeTableProvider.Get(request.OrganisationTypeId, request.TableId);
        }
    }
}