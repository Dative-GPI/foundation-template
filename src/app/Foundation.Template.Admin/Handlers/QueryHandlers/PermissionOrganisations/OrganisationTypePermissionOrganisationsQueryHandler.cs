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
    public class OrganisationTypePermissionOrganisationsQueryHandler : IMiddleware<OrganisationTypePermissionOrganisationsQuery, IEnumerable<OrganisationTypePermissionOrganisationInfos>>
    {
        private IPermissionOrganisationRepository _permissionRepository;
        private IOrganisationTypePermissionRepository _organisationTypePermissionRepository;

        public OrganisationTypePermissionOrganisationsQueryHandler(
            IOrganisationTypePermissionRepository organisationTypePermissionRepository,
            IPermissionOrganisationRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
        }

        public async Task<IEnumerable<OrganisationTypePermissionOrganisationInfos>> HandleAsync(OrganisationTypePermissionOrganisationsQuery request, Func<Task<IEnumerable<OrganisationTypePermissionOrganisationInfos>>> next, CancellationToken cancellationToken)
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