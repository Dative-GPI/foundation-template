using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class UpdateRoleAdminCommandHandler : IMiddleware<UpdateRoleAdminCommand, IEntity<Guid>>
    {
        private IRoleAdminRepository _roleAdminRepository;

        public UpdateRoleAdminCommandHandler(IRoleAdminRepository roleAdminRepository)
        {
            _roleAdminRepository = roleAdminRepository;
        }

        public async Task<IEntity<Guid>> HandleAsync(UpdateRoleAdminCommand request, Func<Task<IEntity<Guid>>> next, CancellationToken cancellationToken)
        {
            var entity = await _roleAdminRepository.Update(new UpdateRoleAdmin()
            {
                Id = request.RoleAdminId,
                PermissionIds = request.PermissionIds
            });

            return entity;
        }
    }
}