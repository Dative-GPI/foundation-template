using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;

using static Foundation.Template.Core.AutoMapper.Consts;

namespace Foundation.Template.Core.Services
{
    public class RoleOrganisationService : IRoleOrganisationService
    {
        private readonly IQueryHandler<RoleOrganisationQuery, RoleOrganisationDetails> _roleOrganisationQueryHandler;
        private readonly ICommandHandler<UpdateRoleOrganisationCommand, IEntity<Guid>> _updateRoleOrganisationCommandHandler;
        private readonly IRoleOrganisationRepository _roleOrganisationRepository;
        private readonly IRequestContextProvider _requestContextProvider;
        private readonly IMapper _mapper;

        public RoleOrganisationService(
            IQueryHandler<RoleOrganisationQuery, RoleOrganisationDetails> roleOrganisationQueryHandler,
            ICommandHandler<UpdateRoleOrganisationCommand, IEntity<Guid>> updateRoleOrganisationCommandHandler,
            IRequestContextProvider requestContextProvider,
            IRoleOrganisationRepository roleOrganisationRepository,
            IMapper mapper
        )
        {
            _roleOrganisationQueryHandler = roleOrganisationQueryHandler;
            _updateRoleOrganisationCommandHandler = updateRoleOrganisationCommandHandler;

            _roleOrganisationRepository = roleOrganisationRepository;

            _requestContextProvider = requestContextProvider;
            _mapper = mapper;
        }

        public async Task<RoleOrganisationDetailsViewModel> Get(Guid roleId)
        {
            var query = new RoleOrganisationQuery() {
                RoleOrganisationId = roleId
            };

            var result = await _roleOrganisationQueryHandler.HandleAsync(query);

            var context = _requestContextProvider.Context;
            return _mapper.Map<RoleOrganisationDetails, RoleOrganisationDetailsViewModel>(result, opt => opt.Items.Add(LANGUAGE, context.LanguageCode));
        }

        public async Task<RoleOrganisationDetailsViewModel> Update(Guid roleId, UpdateRoleOrganisationViewModel payload)
        {
            var command = new UpdateRoleOrganisationCommand() {
                RoleOrganisationId = roleId,
                PermissionIds = payload.PermissionIds
            };

            var entity = await _updateRoleOrganisationCommandHandler.HandleAsync(command);
            var result = await _roleOrganisationRepository.Get(entity.Id);

            var context = _requestContextProvider.Context;
            return _mapper.Map<RoleOrganisationDetails, RoleOrganisationDetailsViewModel>(result, opt => opt.Items.Add(LANGUAGE, context.LanguageCode));
        }
    }
}