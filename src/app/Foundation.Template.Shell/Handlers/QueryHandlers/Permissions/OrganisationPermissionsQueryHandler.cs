using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Shell.Abstractions;

namespace Foundation.Template.Shell.Handlers
{
    public class PermissionsQueryHandler : IMiddleware<PermissionsQuery, IEnumerable<PermissionInfos>>
    {
        private readonly IOrganisationTypePermissionRepository _organisationTypePermissionRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRequestContextProvider _requestContextProvider;

        public PermissionsQueryHandler(
            IOrganisationTypePermissionRepository organisationTypePermissionRepository,
            IPermissionRepository permissionRepository,
            IRequestContextProvider requestContextProvider
        )
        {
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
            _permissionRepository = permissionRepository;
            
            _requestContextProvider = requestContextProvider;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(PermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var context = _requestContextProvider.Context;

            var organisationTypePermissions = await _organisationTypePermissionRepository.GetMany(new OrganisationTypePermissionsFilter() {
                OrganisationTypeId = context.OrganisationTypeId
            });

            var permissions = await _permissionRepository.GetMany(new PermissionsFilter()
            {
                PermissionIds = organisationTypePermissions.Select(p => p.PermissionId).ToList()
            });

            return permissions;
        }
    }
}