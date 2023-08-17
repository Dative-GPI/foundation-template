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
    public class OrganisationTypePermissionsQueryHandler : IMiddleware<OrganisationTypePermissionsQuery, IEnumerable<OrganisationTypePermissionInfos>>
    {
        private IPermissionOrganisationRepository _permissionRepository;
        private IOrganisationTypePermissionRepository _organisationTypePermissionRepository;

        public OrganisationTypePermissionsQueryHandler(
            IOrganisationTypePermissionRepository organisationTypePermissionRepository,
            IPermissionOrganisationRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
        }

        public async Task<IEnumerable<OrganisationTypePermissionInfos>> HandleAsync(OrganisationTypePermissionsQuery request, Func<Task<IEnumerable<OrganisationTypePermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new OrganisationTypePermissionsFilter()
            {
                OrganisationTypeId = request.OrganisationTypeId
            };

            var orgTypePermissions = await _organisationTypePermissionRepository.GetMany(filter);

            return orgTypePermissions;
        }
    }
}