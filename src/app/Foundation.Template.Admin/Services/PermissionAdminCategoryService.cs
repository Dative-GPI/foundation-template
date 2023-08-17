using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Services
{
    public class PermissionAdminCategoryService : IPermissionAdminCategoryService
    {
        private IQueryHandler<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>> _permissionAdminCategoriesQueryHandler;
        private IMapper _mapper;

        public PermissionAdminCategoryService(
            IQueryHandler<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>> permissionAdminCategoriesQueryHandler,
            IMapper mapper
        )
        {
            _permissionAdminCategoriesQueryHandler = permissionAdminCategoriesQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionAdminCategoryViewModel>> GetMany()
        {
            var query = new PermissionAdminCategoriesQuery() {
            };

            var result = await _permissionAdminCategoriesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionAdminCategory>, IEnumerable<PermissionAdminCategoryViewModel>>(result);
        }
    }
}