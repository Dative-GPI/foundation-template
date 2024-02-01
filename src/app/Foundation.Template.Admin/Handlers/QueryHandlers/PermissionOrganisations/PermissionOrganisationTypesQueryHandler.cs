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
    public class PermissionOrganisationTypesQueryHandler : IMiddleware<PermissionOrganisationTypesQuery, IEnumerable<PermissionOrganisationTypeInfos>>
    {
        private IPermissionOrganisationRepository _permissionRepository;
        private IPermissionOrganisationTypeRepository _permissionOrganisationTypeRepository;

        public PermissionOrganisationTypesQueryHandler(
            IPermissionOrganisationTypeRepository permissionOrganisationTypeRepository,
            IPermissionOrganisationRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionOrganisationTypeRepository = permissionOrganisationTypeRepository;
        }

        public async Task<IEnumerable<PermissionOrganisationTypeInfos>> HandleAsync(PermissionOrganisationTypesQuery request, Func<Task<IEnumerable<PermissionOrganisationTypeInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionOrganisationTypesFilter()
            {
                OrganisationTypeId = request.OrganisationTypeId
            };

            var orgTypePermissions = await _permissionOrganisationTypeRepository.GetMany(filter);

            return orgTypePermissions;
        }
    }
}