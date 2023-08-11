using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class PermissionCategoriesQueryHandler : IMiddleware<PermissionCategoriesQuery, IEnumerable<PermissionCategory>>
    {
        private IPermissionCategoryRepository _permissionCategoryRepository;
        
        public PermissionCategoriesQueryHandler(IPermissionCategoryRepository permissionCategoryRepository)
        {
            _permissionCategoryRepository = permissionCategoryRepository;
        }

        public async Task<IEnumerable<PermissionCategory>> HandleAsync(PermissionCategoriesQuery request, Func<Task<IEnumerable<PermissionCategory>>> next, CancellationToken cancellationToken)
        {
            return await _permissionCategoryRepository.GetMany();
        }
    }
}