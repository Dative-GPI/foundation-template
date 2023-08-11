using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Admin.Abstractions;

namespace Foundation.Template.Admin.Services
{
    public class PermissionAdminService : IPermissionAdminService
    {
        private IQueryHandler<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>> _permissionAdminsQueryHandler;
        private IRequestContextProvider _requestContextProvider;
        private IPermissionProvider _permissionProvider;
        private IMapper _mapper;

        public PermissionAdminService(
            IQueryHandler<PermissionAdminsQuery, IEnumerable<PermissionAdminInfos>> permissionAdminsQueryHandler,
            IRequestContextProvider requestContextProvider,
            IPermissionProvider permissionProvider,
            IMapper mapper
        )
        {
            _permissionAdminsQueryHandler = permissionAdminsQueryHandler;
            _requestContextProvider = requestContextProvider;
            _permissionProvider = permissionProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionAdminInfosViewModel>> GetMany(PermissionAdminFilterViewModel filter)
        {
            var query = new PermissionAdminsQuery()
            {
                Search = filter.Search,
                RoleAdminId = filter.RoleAdminId,
                PermissionAdminIds = filter.PermissionAdminIds
            };

            var result = await _permissionAdminsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionAdminInfos>, IEnumerable<PermissionAdminInfosViewModel>>(result);
        }

        public async Task<IEnumerable<string>> GetCurrent()
        {
            return await _permissionProvider.GetPermissions(_requestContextProvider.Context.ActorId);
        }
    }
}