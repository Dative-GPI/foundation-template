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
    public class PermissionAdminsQueryHandler : IMiddleware<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>>
    {
        private IPermissionAdminRepository _permissionAdminRepository;
        
        public PermissionAdminsQueryHandler(IPermissionAdminRepository permissionAdminRepository)
        {
            _permissionAdminRepository = permissionAdminRepository;
        }

        public async Task<IEnumerable<PermissionAdminInfos>> HandleAsync(PermissionAdminsQuery request, Func<Task<IEnumerable<PermissionAdminInfos>>> next, CancellationToken cancellationToken)
        {
            var filter = new PermissionAdminFilter()
            {
                Search = request.Search
            };

            return await _permissionAdminRepository.GetMany(filter);
        }
    }
}