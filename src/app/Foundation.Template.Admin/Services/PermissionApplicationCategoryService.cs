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
    public class PermissionApplicationCategoryService : IPermissionApplicationCategoryService
    {
        private IQueryHandler<PermissionApplicationCategoriesQuery, IEnumerable<PermissionApplicationCategory>> _permissionApplicationCategoriesQueryHandler;
        private IMapper _mapper;

        public PermissionApplicationCategoryService(
            IQueryHandler<PermissionApplicationCategoriesQuery, IEnumerable<PermissionApplicationCategory>> permissionApplicationCategoriesQueryHandler,
            IMapper mapper
        )
        {
            _permissionApplicationCategoriesQueryHandler = permissionApplicationCategoriesQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionApplicationCategoryViewModel>> GetMany()
        {
            var query = new PermissionApplicationCategoriesQuery() {
            };

            var result = await _permissionApplicationCategoriesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionApplicationCategory>, IEnumerable<PermissionApplicationCategoryViewModel>>(result);
        }
    }
}