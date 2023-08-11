using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Services
{
    public class OrganisationTypePermissionService : IOrganisationTypePermissionService
    {
        private IQueryHandler<OrganisationTypePermissionsQuery, IEnumerable<OrganisationTypePermissionInfos>> _organisationTypePermissionsQueryHandler;
        private ICommandHandler<UpsertOrganisationTypePermissionsCommand> _updateOrganisationTypePermissionsCommand;
        private IPermissionRepository _permissionRepository;
        private IMapper _mapper;

        public OrganisationTypePermissionService(
            IQueryHandler<OrganisationTypePermissionsQuery, IEnumerable<OrganisationTypePermissionInfos>> organisationTypePermissionsQuery,
            ICommandHandler<UpsertOrganisationTypePermissionsCommand> updateOrganisationTypePermissionsCommand,
            IPermissionRepository permissionRepository,
            IMapper mapper
        )
        {
            _organisationTypePermissionsQueryHandler = organisationTypePermissionsQuery;
            _updateOrganisationTypePermissionsCommand = updateOrganisationTypePermissionsCommand;
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganisationTypePermissionInfosViewModel>> GetMany(OrganisationTypePermissionsFilterViewModel filter)
        {
            var query = new OrganisationTypePermissionsQuery()
            {
                OrganisationTypeId = filter.OrganisationTypeId
            };

            var result = await _organisationTypePermissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<OrganisationTypePermissionInfos>, IEnumerable<OrganisationTypePermissionInfosViewModel>>(result);
        }

        public async Task Upsert(List<UpsertOrganisationTypePermissionsViewModel> payload)
        {
            var command = new UpsertOrganisationTypePermissionsCommand()
            {
                OrganisationTypePermissions = payload.Select(tr => new UpsertOrganisationTypePermissions()
                {
                    OrganisationTypeId = tr.OrganisationTypeId,
                    PermissionIds = tr.PermissionIds
                }).ToList()
            };

            await _updateOrganisationTypePermissionsCommand.HandleAsync(command);
        }
    }
}