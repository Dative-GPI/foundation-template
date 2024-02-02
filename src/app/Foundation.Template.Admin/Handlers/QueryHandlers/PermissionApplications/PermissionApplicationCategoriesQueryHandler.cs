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
    public class PermissionApplicationCategoriesQueryHandler : IMiddleware<PermissionApplicationCategoriesQuery, IEnumerable<PermissionApplicationCategory>>
    {
        private IPermissionApplicationCategoryRepository _permissionApplicationCategoryRepository;
        
        public PermissionApplicationCategoriesQueryHandler(IPermissionApplicationCategoryRepository permissionApplicationCategoryRepository)
        {
            _permissionApplicationCategoryRepository = permissionApplicationCategoryRepository;
        }

        public async Task<IEnumerable<PermissionApplicationCategory>> HandleAsync(PermissionApplicationCategoriesQuery request, Func<Task<IEnumerable<PermissionApplicationCategory>>> next, CancellationToken cancellationToken)
        {
            return await _permissionApplicationCategoryRepository.GetMany();
        }
    }
}