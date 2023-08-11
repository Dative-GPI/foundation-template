using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Services
{
    public class PermissionCategoryService : IPermissionCategoryService
    {
        private IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> _permissionCategoriesQueryHandler;
        private IMapper _mapper;

        public PermissionCategoryService(
            IQueryHandler<PermissionCategoriesQuery, IEnumerable<PermissionCategory>> permissionCategoriesQueryHandler,
            IMapper mapper
        )
        {
            _permissionCategoriesQueryHandler = permissionCategoriesQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionCategoryViewModel>> GetMany()
        {
            var query = new PermissionCategoriesQuery() {
            };

            var result = await _permissionCategoriesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionCategory>, IEnumerable<PermissionCategoryViewModel>>(result);
        }
    }
}