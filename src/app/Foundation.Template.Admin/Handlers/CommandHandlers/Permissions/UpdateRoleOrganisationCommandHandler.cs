using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class UpdateRoleOrganisationCommandHandler : IMiddleware<UpdateRoleOrganisationCommand, IEntity<Guid>>
    {
        private IRoleOrganisationRepository _roleOrganisationRepository;

        public UpdateRoleOrganisationCommandHandler(IRoleOrganisationRepository roleOrganisationRepository)
        {
            _roleOrganisationRepository = roleOrganisationRepository;
        }

        public async Task<IEntity<Guid>> HandleAsync(UpdateRoleOrganisationCommand request, Func<Task<IEntity<Guid>>> next, CancellationToken cancellationToken)
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