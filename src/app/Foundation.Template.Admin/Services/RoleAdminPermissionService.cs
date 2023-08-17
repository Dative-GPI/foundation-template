using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Domain.Repositories.Filters;
using Bones.Repository.Interfaces;

namespace Foundation.Template.Admin.Services
{
    public class RoleAdminService : IRoleAdminService
    {
        private IRoleAdminRepository _roleAdminRepository;
        private IQueryHandler<RoleAdminQuery, RoleAdminDetails> _roleAdminQueryHandler;
        private ICommandHandler<UpdateRoleAdminCommand, IEntity<Guid>> _updateRoleAdminCommandHandler;
        private IMapper _mapper;

        public RoleAdminService(
            IQueryHandler<RoleAdminQuery, RoleAdminDetails> roleQueryHandler,
            ICommandHandler<UpdateRoleAdminCommand, IEntity<Guid>> updateRoleCommandHandler,
            IRoleAdminRepository roleAdminRepository,
            IMapper mapper
        )
        {
            _roleAdminQueryHandler = roleQueryHandler;
            _updateRoleAdminCommandHandler = updateRoleCommandHandler;
            
            _roleAdminRepository = roleAdminRepository;
            _mapper = mapper;
        }

        public async Task<RoleAdminDetailsViewModel> Get(Guid id)
        {
            var query = new RoleAdminQuery()
            {
                RoleAdminId = id
            };

            var result = await _roleAdminQueryHandler.HandleAsync(query);

            return _mapper.Map<RoleAdminDetails, RoleAdminDetailsViewModel>(result);
        }

        public async Task<RoleAdminDetailsViewModel> Update(Guid id, UpdateRoleAdminViewModel payload)
        {
            var command = new UpdateRoleAdminCommand()
            {
                RoleAdminId = id,
                PermissionIds = payload.PermissionIds,
                ExtensionData = payload.ExtensionData
            };

            var entity = await _updateRoleAdminCommandHandler.HandleAsync(command);
            var result = await _roleAdminRepository.Get(entity.Id);

            return _mapper.Map<RoleAdminDetails, RoleAdminDetailsViewModel>(result);
        }
    }
}