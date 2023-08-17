using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Shell.Abstractions;
using Foundation.Template.Shell.Abstractions;
using Foundation.Template.Shell.ViewModels;

using static Foundation.Template.Shell.AutoMapper.Consts;

namespace Foundation.Template.Shell.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionProvider _permissionProvider;
        private readonly IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> _categoriesQueryHandler;
        private readonly IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>> _permissionsQueryHandler;
        private readonly IRequestContextProvider _requestContextProvider;
        private readonly IMapper _mapper;

        public PermissionService(
            IQueryHandler<PermissionsQuery, IEnumerable<PermissionInfos>> permissionsQueryHandler,
            IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> categoriesQueryHandler,
            IRequestContextProvider requestContextProvider,
            IPermissionProvider permissionProvider,
            IMapper mapper
        )
        {
            _categoriesQueryHandler = categoriesQueryHandler;
            _permissionsQueryHandler = permissionsQueryHandler;

            _requestContextProvider = requestContextProvider;
            _permissionProvider = permissionProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetCurrent()
        {
            var context = _requestContextProvider.Context;
            return await _permissionProvider.GetPermissions(context.OrganisationId.Value, context.ActorId);
        }

        public async Task<IEnumerable<PermissionCategoryViewModel>> GetCategories()
        {
            var query = new PermissionCategoriesQuery();

            var categories = await _categoriesQueryHandler.HandleAsync(query);

            var context = _requestContextProvider.Context;
            return _mapper.Map<IEnumerable<PermissionCategory>, IEnumerable<PermissionCategoryViewModel>>(categories, opt => opt.Items.Add(LANGUAGE, context.LanguageCode));
        }

        public async Task<IEnumerable<PermissionInfosViewModel>> GetMany()
        {
            var query = new PermissionsQuery();

            var result = await _permissionsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionInfos>, IEnumerable<PermissionInfosViewModel>>(result);
        }
    }
}