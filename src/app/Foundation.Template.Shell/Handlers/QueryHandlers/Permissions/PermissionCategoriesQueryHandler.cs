using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Shell.Handlers {
    public class PermissionCategoriesQueryHandler : IMiddleware<PermissionCategoriesQuery, IEnumerable<PermissionCategory>>
    {
        private readonly IPermissionOrganisationCategoryRepository _permissionCategoryRepository;

        public PermissionCategoriesQueryHandler(
            IPermissionOrganisationCategoryRepository permissionCategoryRepository
        )
        {
            _permissionCategoryRepository = permissionCategoryRepository;
        }

        public async Task<IEnumerable<PermissionCategory>> HandleAsync(PermissionCategoriesQuery request, Func<Task<IEnumerable<PermissionCategory>>> next, CancellationToken cancellationToken)
        {
            var categories = await _permissionCategoryRepository.GetMany();
            return categories;
        }
    }
}