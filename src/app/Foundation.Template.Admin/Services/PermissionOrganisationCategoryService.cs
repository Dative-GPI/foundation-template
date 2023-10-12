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
    public class PermissionOrganisationCategoryService : IPermissionOrganisationCategoryService
    {
        private IQueryHandler<PermissionOrganisationCategoriesQuery, IEnumerable<PermissionOrganisationCategory>> _permissionCategoriesQueryHandler;
        private IMapper _mapper;

        public PermissionOrganisationCategoryService(
            IQueryHandler<PermissionOrganisationCategoriesQuery, IEnumerable<PermissionOrganisationCategory>> permissionCategoriesQueryHandler,
            IMapper mapper
        )
        {
            _permissionCategoriesQueryHandler = permissionCategoriesQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionOrganisationCategoryViewModel>> GetMany()
        {
            var query = new PermissionOrganisationCategoriesQuery() {
            };

            var result = await _permissionCategoriesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<PermissionOrganisationCategory>, IEnumerable<PermissionOrganisationCategoryViewModel>>(result);
        }
    }
}