using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class UpsertOrganisationTypePermissionOrganistionsCommandHandler : IMiddleware<UpsertOrganisationTypePermissionOrganisationsCommand>
    {
        private IOrganisationTypePermissionRepository _organisationTypePermissionRepository;

        public UpsertOrganisationTypePermissionOrganistionsCommandHandler(IOrganisationTypePermissionRepository organisationTypePermissionRepository)
        {
            _organisationTypePermissionRepository = organisationTypePermissionRepository;
        }

        public async Task HandleAsync(UpsertOrganisationTypePermissionOrganisationsCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var filter = new OrganisationTypePermissionsFilter()
            {
                OrganisationTypeIds = request.OrganisationTypePermissions.Select(ot => ot.OrganisationTypeId)
            };

            // Get former permissions
            var formerIds = await _organisationTypePermissionRepository.GetMany(filter);

            // Remove former permissions
            await _organisationTypePermissionRepository.RemoveRange(formerIds.Select(p => p.Id).ToArray());

            // Create the new permissions
            await _organisationTypePermissionRepository.CreateRange(request.OrganisationTypePermissions
                .SelectMany(ps => ps.PermissionIds
                    .Select(p => new CreateOrganisationTypePermission()
                    {
                        OrganisationTypeId = ps.OrganisationTypeId,
                        PermissionId = p
                    })
                )
            );
        }
    }
}