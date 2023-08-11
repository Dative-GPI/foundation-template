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
    public class RoleAdminQueryHandler : IMiddleware<RoleAdminQuery, RoleAdminDetails>
    {
        private IPermissionAdminRepository _permissionAdminRepository;
        private IRoleAdminRepository _roleAdminRepository;

        public RoleAdminQueryHandler(
            IRoleAdminRepository roleAdminRepository,
            IPermissionAdminRepository permissionAdminRepository)
        {
            _permissionAdminRepository = permissionAdminRepository;
            _roleAdminRepository = roleAdminRepository;
        }

        public async Task<RoleAdminDetails> HandleAsync(RoleAdminQuery request, Func<Task<RoleAdminDetails>> next, CancellationToken cancellationToken)
        {
            var result = await _roleAdminRepository.Get(request.RoleAdminId);
            return result;
        }
    }
}