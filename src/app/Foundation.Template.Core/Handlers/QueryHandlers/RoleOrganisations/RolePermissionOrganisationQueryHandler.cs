using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Handlers
{
    public class RolePermissionOrganisationQueryHandler : IMiddleware<RolePermissionOrganisationQuery, RolePermissionOrganisationDetails>
    {
        private readonly IRolePermissionOrganisationRepository _roleOrganisationRepository;

        public RolePermissionOrganisationQueryHandler(
            IRolePermissionOrganisationRepository roleOrganisationRepository
        )
        {
            _roleOrganisationRepository = roleOrganisationRepository;
        }

        public async Task<RolePermissionOrganisationDetails> HandleAsync(RolePermissionOrganisationQuery request, Func<Task<RolePermissionOrganisationDetails>> next, CancellationToken cancellationToken)
        {
            var role = await _roleOrganisationRepository.Get(request.RoleOrganisationId);

            return role;
        }
    }
}