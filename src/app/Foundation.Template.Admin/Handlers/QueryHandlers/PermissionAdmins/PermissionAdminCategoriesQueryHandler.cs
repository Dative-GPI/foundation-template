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
    public class PermissionAdminCategoriesQueryHandler : IMiddleware<PermissionAdminCategoriesQuery, IEnumerable<PermissionAdminCategory>>
    {
        private IPermissionAdminCategoryRepository _permissionAdminCategoryRepository;
        
        public PermissionAdminCategoriesQueryHandler(IPermissionAdminCategoryRepository permissionAdminCategoryRepository)
        {
            _permissionAdminCategoryRepository = permissionAdminCategoryRepository;
        }

        public async Task<IEnumerable<PermissionAdminCategory>> HandleAsync(PermissionAdminCategoriesQuery request, Func<Task<IEnumerable<PermissionAdminCategory>>> next, CancellationToken cancellationToken)
        {
            return await _permissionAdminCategoryRepository.GetMany();
        }
    }
}