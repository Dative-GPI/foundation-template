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
    public class PermissionOrganisationTypeService : IPermissionOrganisationTypeService
    {
        private IQueryHandler<PermissionOrganisationTypesQuery, IEnumerable<PermissionOrganisationTypeInfos>> _permissionOrganisationTypesQueryHandler;
        private ICommandHandler<UpsertPermissionOrganisationTypesCommand> _updatePermissionOrganisationTypesCommand;
        private IMapper _mapper;

        public PermissionOrganisationTypeService(
            IQueryHandler<PermissionOrganisationTypesQuery, IEnumerable<PermissionOrganisationTypeInfos>> permissionOrganisationTypesQuery,
            ICommandHandler<UpsertPermissionOrganisationTypesCommand> updatePermissionOrganisationTypesCommand,
            IMapper mapper
        )
        {
            _permissionOrganisationTypesQueryHandler = permissionOrganisationTypesQuery;
            _updatePermissionOrganisationTypesCommand = updatePermissionOrganisationTypesCommand;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionOrganisationTypeInfosViewModel>> GetMany(PermissionOrganisationTypesFilterViewModel filter)
        {
            var query = new PermissionOrganisationTypesQuery()
            {
                OrganisationTypeId = filter.OrganisationTypeId
            };

            var result = await _permissionOrganisationTypesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionOrganisationTypeInfos>, IEnumerable<PermissionOrganisationTypeInfosViewModel>>(result);
        }

        public async Task Upsert(List<UpsertPermissionOrganisationTypesViewModel> payload)
        {
            var command = new UpsertPermissionOrganisationTypesCommand()
            {
                PermissionOrganisationTypes = payload.Select(tr => new UpsertPermissionOrganisationTypes()
                {
                    OrganisationTypeId = tr.OrganisationTypeId,
                    PermissionIds = tr.PermissionIds
                }).ToList()
            };

            await _updatePermissionOrganisationTypesCommand.HandleAsync(command);
        }
    }
}