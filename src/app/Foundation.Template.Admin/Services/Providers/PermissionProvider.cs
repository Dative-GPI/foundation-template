using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Foundation.Clients.ViewModels.Admin;
using Foundation.Clients.Abstractions;

using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;
using Foundation.Template.Domain.Abstractions;

using Foundation.Template.Admin.Abstractions;

namespace Foundation.Template.Admin.Tools
{
    public class PermissionProvider : IPermissionProvider
    {
        private readonly IFoundationClientFactory _foundationClientFactory;
        private readonly IRoleAdminRepository _roleAdminRepository;
        private readonly IRequestContextProvider _requestContextProvider;

        public PermissionProvider(
            IFoundationClientFactory foundationClientFactory,
            IRoleAdminRepository roleAdminRepository,
            IRequestContextProvider requestContextProvider
        )
        {
            _foundationClientFactory = foundationClientFactory;
            _roleAdminRepository = roleAdminRepository;
            _requestContextProvider = requestContextProvider;
        }


        public async Task<bool> HasPermissions(Guid actorId, params string[] permissions)
        {
            var grantedPermissions = await GetPermissions(actorId);
            return !permissions.Except(grantedPermissions).Any(); // Checking if permissions is a subset of grantedPermissions
            // Code from https://stackoverflow.com/a/333034
            // Interesting conversation under this comment : https://stackoverflow.com/a/26697119
        }


        public async Task<IEnumerable<string>> GetPermissions(Guid actorId)
        {
            List<string> permissions = new List<string>();
            var context = _requestContextProvider.Context;

            var client = await _foundationClientFactory.CreateAuthenticated(context.ApplicationId, context.LanguageCode, context.Jwt);

            var foundationPermissions = await client.Admin.Permissions.GetCurrent();

            var localPermissions = await GetLocalPermissions(client, actorId);

            return foundationPermissions.Select(fp => fp.Code).Union(localPermissions).ToList();
        }
        private async Task<IEnumerable<string>> GetLocalPermissions(IFoundationClient client, Guid userId)
        {
            var userApplication = await client.Admin.UserApplications.GetCurrent();

            if (userApplication.RoleAdminId.HasValue)
            {
                var role = await _roleAdminRepository.Get(userApplication.RoleAdminId.Value);

                return role.Permissions.Select(p => p.Code);
            }

            return Enumerable.Empty<string>();
        }
    }
}