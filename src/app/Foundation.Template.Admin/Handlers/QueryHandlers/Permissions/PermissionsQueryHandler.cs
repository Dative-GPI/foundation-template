using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class PermissionsQueryHandler : IMiddleware<PermissionsQuery, IEnumerable<PermissionInfos>>
    {
        private IPermissionRepository _permissionRepository;
        
        public PermissionsQueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(PermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionsFilter()
            {
                Search = request.Search,
                OrganisationTypeId = request.OrganisationTypeId,
                RoleId = request.RoleId,
                PermissionIds = request.PermissionIds
            };

            return await _permissionRepository.GetMany(filter);
        }
    }
}