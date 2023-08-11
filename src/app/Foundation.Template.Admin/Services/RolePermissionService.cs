using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Services
{
    public class RoleOrganisationService : IRoleOrganisationService
    {
        private IQueryHandler<RoleOrganisationQuery, RoleOrganisationDetails> _roleOrganisationQueryHandler;
        private ICommandHandler<UpdateRoleOrganisationCommand, IEntity<Guid>> _updateRoleOrganisationCommandHandler;
        private IRoleOrganisationRepository _roleOrganisationRepository;
        private IMapper _mapper;

        public RoleOrganisationService(
            IQueryHandler<RoleOrganisationQuery, RoleOrganisationDetails> roleOrganisationQueryHandler,
            ICommandHandler<UpdateRoleOrganisationCommand, IEntity<Guid>> updateRoleOrganisationCommandHandler,
            IRoleOrganisationRepository roleOrganisationRepository,
            IMapper mapper
        )
        {
            _roleOrganisationQueryHandler = roleOrganisationQueryHandler;
            _updateRoleOrganisationCommandHandler = updateRoleOrganisationCommandHandler;
            _roleOrganisationRepository = roleOrganisationRepository;
            _mapper = mapper;
        }

        public async Task<RoleOrganisationDetailsViewModel> Get(Guid id)
        {
            var query = new RoleOrganisationQuery()
            {
                RoleOrganisationId = id
            };

            var result = await _roleOrganisationQueryHandler.HandleAsync(query);

            return _mapper.Map<RoleOrganisationDetails, RoleOrganisationDetailsViewModel>(result);
        }

        public async Task<RoleOrganisationDetailsViewModel> Update(Guid id, UpdateRoleOrganisationViewModel payload)
        {
            var command = new UpdateRoleOrganisationCommand()
            {
                RoleOrganisationId = id,
                PermissionIds = payload.PermissionIds,
                ExtensionData = payload.ExtensionData
            };

            var entity = await _updateRoleOrganisationCommandHandler.HandleAsync(command);
            var result = await _roleOrganisationRepository.Get(entity.Id);

            return _mapper.Map<RoleOrganisationDetails, RoleOrganisationDetailsViewModel>(result);
        }
    }
}