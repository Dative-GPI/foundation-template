using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class RoleApplicationQueryHandler : IMiddleware<RoleApplicationQuery, RoleApplicationDetails>
    {
        private IRoleApplicationRepository _roleApplicationRepository;

        public RoleApplicationQueryHandler(
            IRoleApplicationRepository roleApplicationRepository)
        {
            _roleApplicationRepository = roleApplicationRepository;
        }

        public async Task<RoleApplicationDetails> HandleAsync(RoleApplicationQuery request, Func<Task<RoleApplicationDetails>> next, CancellationToken cancellationToken)
        {
            var result = await _roleApplicationRepository.Get(request.RoleApplicationId);
            
            return result;
        }
    }
}