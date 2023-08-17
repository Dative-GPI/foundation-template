using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Foundation.Clients.Abstractions;
using Foundation.Clients.ViewModels.Shell;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;
using Foundation.Template.Shell.Abstractions;
using Foundation.Template.Domain.Abstractions;

namespace Foundation.Template.Shell.Tools
{
    public class PermissionProvider : IPermissionProvider
    {
        private readonly IFoundationClientFactory _foundationClientFactory;
        private readonly IRoleOrganisationRepository _roleOrganisationRepository;
        private readonly IOrganisationTypePermissionRepository _organisationTypePermissionRepository;
        private readonly IRequestContextProvider _requestContextProvider;

        public PermissionProvider(
            IFoundationClientFactory foundationClientFactory,
            IRoleOrganisationRepository roleOrganisationRepository,
            IOrganisationTypePermissionRepository organisationTypePermissionRepository,
            IRequestContextProvider requestContextProvider
        )
        {
            _foundationClientFactory = foundationClientFactory;
            _roleOrganisationRepository = roleOrganisationRepository;
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
            _requestContextProvider = requestContextProvider;
        }


        public async Task<bool> HasPermissions(params string[] permissions)
        {
            var grantedPermissions = await GetPermissions();
            return !permissions.Except(grantedPermissions).Any(); // Checking if permissions is a subset of grantedPermissions
            // Code from https://stackoverflow.com/a/333034
            // Interesting conversation under this comment : https://stackoverflow.com/a/26697119
        }


        public async Task<IEnumerable<string>> GetPermissions()
        {
            var context = _requestContextProvider.Context;
            var organisationId = context.OrganisationId.Value;

            var client = await _foundationClientFactory.CreateAuthenticated(context.ApplicationId, context.LanguageCode, context.Jwt);
            var foundationPermissions = await GetFoundationPermissions(client, organisationId);

            var organisation = await client.Shell.Organisations.Get(organisationId);
            var organisationTypePermissions = await GetOrganisationTypePermissions(organisation.OrganisationTypeId);

            if (organisation.AdminId == context.ActorId)
                return foundationPermissions.Concat(organisationTypePermissions).ToList();

            var userOrganisation = await GetUserOrganisation(client, organisationId, context.ActorId);
            if (userOrganisation == default || !userOrganisation.RoleId.HasValue)
                return foundationPermissions;

            var roleOrganisationPermissions = await GetRoleOrganisationPermissions(userOrganisation.RoleId.Value);

            return foundationPermissions.Concat(
                roleOrganisationPermissions.Intersect(organisationTypePermissions).ToList()
            ).ToList();
            // use of intersect to make sure that the permissions of a role is a subset of
            // the permissions of an organisationType 
        }

        private async Task<IEnumerable<string>> GetFoundationPermissions(IFoundationClient client, Guid organisationId)
        {
            var permissions = await client.Shell.Permissions.GetMany(organisationId);
            return permissions.Select(permission => permission.Code).ToList();
        }

        private async Task<IEnumerable<string>> GetOrganisationTypePermissions(Guid organisationTypeId)
        {
            var organisationTypePermissions = await _organisationTypePermissionRepository.GetMany(
                new OrganisationTypePermissionsFilter()
                {
                    OrganisationTypeId = organisationTypeId
                }
            );

            return organisationTypePermissions.Select(otp => otp.PermissionCode).ToList();
        }

        private async Task<IEnumerable<string>> GetRoleOrganisationPermissions(Guid roleId)
        {
            var role = await _roleOrganisationRepository.Get(roleId);

            return role.Permissions.Select(rp => rp.Code).ToList();
        }

        private async Task<UserOrganisationInfosViewModel> GetUserOrganisation(IFoundationClient client, Guid organisationId, Guid userId)
        {
            var userOrganisations = await client.Shell.UserOrganisations.GetMany(
                organisationId,
                new UserOrganisationFilterViewModel()
                {
                    UserId = userId
                }
            );
            return userOrganisations.FirstOrDefault();
        }
    }
}