using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Core.Abstractions;
using Microsoft.Extensions.Logging;

namespace Foundation.Template.Core.Handlers
{
    public class PermissionsQueryHandler : IMiddleware<PermissionOrganisationsQuery, IEnumerable<PermissionOrganisationInfos>>
    {
        private readonly ILogger<PermissionsQueryHandler> _logger;
        private readonly IPermissionOrganisationTypeRepository _permissionOrganisationTypeRepository;
        private readonly IPermissionOrganisationRepository _permissionRepository;
        private readonly IRequestContextProvider _requestContextProvider;

        public PermissionsQueryHandler(
            IPermissionOrganisationTypeRepository permissionOrganisationTypeRepository,
            IPermissionOrganisationRepository permissionRepository,
            IRequestContextProvider requestContextProvider,
            ILogger<PermissionsQueryHandler> logger
        )
        {
            _logger = logger;
            _permissionOrganisationTypeRepository = permissionOrganisationTypeRepository;
            _permissionRepository = permissionRepository;
            
            _requestContextProvider = requestContextProvider;
        }

        public async Task<IEnumerable<PermissionOrganisationInfos>> HandleAsync(PermissionOrganisationsQuery request, Func<Task<IEnumerable<PermissionOrganisationInfos>>> next, CancellationToken cancellationToken)
        {
            var context = _requestContextProvider.Context;

            _logger.LogWarning("Fetching permissions for organisation type {OrganisationTypeId}", context.OrganisationTypeId);

            var permissionOrganisationTypes = await _permissionOrganisationTypeRepository.GetMany(new PermissionOrganisationTypesFilter() {
                OrganisationTypeId = context.OrganisationTypeId
            });

            var permissions = await _permissionRepository.GetMany(new PermissionsFilter()
            {
                PermissionIds = permissionOrganisationTypes.Select(p => p.PermissionId).ToList()
            });

            return permissions;
        }
    }
}