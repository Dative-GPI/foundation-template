using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Services
{
    public class PermissionOrganisationService : IPermissionOrganisationService
    {
        private IQueryHandler<PermissionOrganisationsQuery, IEnumerable<PermissionOrganisationInfos>> _permissionsQueryHandler;
        private IMapper _mapper;

        public PermissionOrganisationService(
            IQueryHandler<PermissionOrganisationsQuery, IEnumerable<PermissionOrganisationInfos>> permissionsQueryHandler,
            IMapper mapper
        )
        {
            _permissionsQueryHandler = permissionsQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionOrganisationInfosViewModel>> GetMany(PermissionsFilterViewModel filter)
        {
            var query = new PermissionOrganisationsQuery()
            {
                Search = filter.Search
            };

            var result = await _permissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionOrganisationInfos>, IEnumerable<PermissionOrganisationInfosViewModel>>(result);
        }
    }
}