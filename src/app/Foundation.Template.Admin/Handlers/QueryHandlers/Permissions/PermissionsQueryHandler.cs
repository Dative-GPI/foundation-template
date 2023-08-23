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
        private IPermissionOrganisationRepository _permissionRepository;
        
        public PermissionsQueryHandler(IPermissionOrganisationRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionInfos>> HandleAsync(PermissionsQuery request, Func<Task<IEnumerable<PermissionInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionsFilter()
            {
                Search = request.Search
            };

            return await _permissionRepository.GetMany(filter);
        }
    }
}