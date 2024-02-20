using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class RolePermissionOrganisationQueryHandler : IMiddleware<RolePermissionOrganisationQuery, RolePermissionOrganisationDetails>
    {
        private IRolePermissionOrganisationRepository _roleOrganisationRepository;

        public RolePermissionOrganisationQueryHandler(
            IRolePermissionOrganisationRepository roleOrganisationRepository)
        {
            _roleOrganisationRepository = roleOrganisationRepository;
        }

        public async Task<RolePermissionOrganisationDetails> HandleAsync(RolePermissionOrganisationQuery request, Func<Task<RolePermissionOrganisationDetails>> next, CancellationToken cancellationToken)
        {
            var result = await _roleOrganisationRepository.Get(request.RoleOrganisationId);
            return result;
        }
    }
}