using System;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Shell.Handlers
{
    public class UpdateRolePermissionsCommandHandler : IMiddleware<UpdateRolePermissionsCommand, IEntity<Guid>>
    {
        private IRoleOrganisationRepository _roleOrganisationRepository;

        public UpdateRolePermissionsCommandHandler(IRoleOrganisationRepository roleOrganisationRepository)
        {
            _roleOrganisationRepository = roleOrganisationRepository;
        }

        public async Task<IEntity<Guid>> HandleAsync(UpdateRolePermissionsCommand request, Func<Task<IEntity<Guid>>> next, CancellationToken cancellationToken)
        {
            var entity = await _roleOrganisationRepository.Update(new UpdateRoleOrganisation()
            {
                Id = request.RoleOrganisationId,
                PermissionIds = request.PermissionIds
            });

            return entity;
        }
    }
}