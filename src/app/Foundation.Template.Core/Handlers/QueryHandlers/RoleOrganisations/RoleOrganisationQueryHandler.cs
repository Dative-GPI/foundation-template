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
    public class RoleOrganisationQueryHandler : IMiddleware<RoleOrganisationQuery, RoleOrganisationDetails>
    {
        private readonly IRoleOrganisationRepository _roleOrganisationRepository;

        public RoleOrganisationQueryHandler(
            IRoleOrganisationRepository roleOrganisationRepository
        )
        {
            _roleOrganisationRepository = roleOrganisationRepository;
        }

        public async Task<RoleOrganisationDetails> HandleAsync(RoleOrganisationQuery request, Func<Task<RoleOrganisationDetails>> next, CancellationToken cancellationToken)
        {
            var role = await _roleOrganisationRepository.Get(request.RoleOrganisationId);

            return role;
        }
    }
}