using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Services
{
    public class PermissionService : IPermissionService
    {
        private IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>> _permissionsQueryHandler;
        private IMapper _mapper;

        public PermissionService(
            IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>> permissionsQueryHandler,
            IMapper mapper
        )
        {
            _permissionsQueryHandler = permissionsQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany(PermissionsFilterViewModel filter)
        {
            var query = new PermissionsQuery()
            {
                Search = filter.Search,
                OrganisationTypeId = filter.OrganisationTypeId,
                RoleId = filter.RoleId,
                PermissionIds = filter.PermissionIds
            };

            var result = await _permissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(result);
        }
    }
}