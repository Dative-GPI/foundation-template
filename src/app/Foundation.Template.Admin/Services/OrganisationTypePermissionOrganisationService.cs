using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Services
{
    public class OrganisationTypePermissionOrganisationService : IOrganisationTypePermissionOrganisationService
    {
        private IQueryHandler<OrganisationTypePermissionOrganisationsQuery, IEnumerable<OrganisationTypePermissionOrganisationInfos>> _organisationTypePermissionsQueryHandler;
        private ICommandHandler<UpsertOrganisationTypePermissionOrganisationsCommand> _updateOrganisationTypePermissionsCommand;
        private IMapper _mapper;

        public OrganisationTypePermissionOrganisationService(
            IQueryHandler<OrganisationTypePermissionOrganisationsQuery, IEnumerable<OrganisationTypePermissionOrganisationInfos>> organisationTypePermissionsQuery,
            ICommandHandler<UpsertOrganisationTypePermissionOrganisationsCommand> updateOrganisationTypePermissionsCommand,
            IMapper mapper
        )
        {
            _organisationTypePermissionsQueryHandler = organisationTypePermissionsQuery;
            _updateOrganisationTypePermissionsCommand = updateOrganisationTypePermissionsCommand;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganisationTypePermissionOrganisationInfosViewModel>> GetMany(OrganisationTypePermissionsFilterViewModel filter)
        {
            var query = new OrganisationTypePermissionOrganisationsQuery()
            {
                OrganisationTypeId = filter.OrganisationTypeId
            };

            var result = await _organisationTypePermissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<OrganisationTypePermissionOrganisationInfos>, IEnumerable<OrganisationTypePermissionOrganisationInfosViewModel>>(result);
        }

        public async Task Upsert(List<UpsertOrganisationTypePermissionsViewModel> payload)
        {
            var command = new UpsertOrganisationTypePermissionOrganisationsCommand()
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