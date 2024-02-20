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
    public class RoleApplicationService : IRoleApplicationService
    {
        private IRoleApplicationRepository _roleApplicationRepository;
        private IQueryHandler<RoleApplicationQuery, RoleApplicationDetails> _roleApplicationQueryHandler;
        private ICommandHandler<UpdateRoleApplicationCommand, IEntity<Guid>> _updateRoleApplicationCommandHandler;
        private IMapper _mapper;

        public RoleApplicationService(
            IQueryHandler<RoleApplicationQuery, RoleApplicationDetails> roleQueryHandler,
            ICommandHandler<UpdateRoleApplicationCommand, IEntity<Guid>> updateRoleCommandHandler,
            IRoleApplicationRepository roleApplicationRepository,
            IMapper mapper
        )
        {
            _roleApplicationQueryHandler = roleQueryHandler;
            _updateRoleApplicationCommandHandler = updateRoleCommandHandler;
            
            _roleApplicationRepository = roleApplicationRepository;
            _mapper = mapper;
        }

        public async Task<RoleApplicationDetailsViewModel> Get(Guid id)
        {
            var query = new RoleApplicationQuery()
            {
                RoleApplicationId = id
            };

            var result = await _roleApplicationQueryHandler.HandleAsync(query);

            return _mapper.Map<RoleApplicationDetails, RoleApplicationDetailsViewModel>(result);
        }

        public async Task<RoleApplicationDetailsViewModel> Update(Guid id, UpdateRoleApplicationViewModel payload)
        {
            var command = new UpdateRoleApplicationCommand()
            {
                RoleApplicationId = id,
                PermissionIds = payload.PermissionIds,
                ExtensionData = payload.ExtensionData
            };

            var entity = await _updateRoleApplicationCommandHandler.HandleAsync(command);
            var result = await _roleApplicationRepository.Get(entity.Id);

            return _mapper.Map<RoleApplicationDetails, RoleApplicationDetailsViewModel>(result);
        }
    }
}