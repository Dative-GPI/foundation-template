using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Handlers
{
    public class UserOrganisationTableQueryHandler : IMiddleware<UserOrganisationTableQuery, UserOrganisationTable>
    {
        private readonly IUserOrganisationTableRepository _userOrganisationTableRepository;

        public UserOrganisationTableQueryHandler(IUserOrganisationTableRepository userOrganisationTableRepository)
        {
            _userOrganisationTableRepository = userOrganisationTableRepository;
        }


        public async Task<UserOrganisationTable> HandleAsync(UserOrganisationTableQuery request, Func<Task<UserOrganisationTable>> next, CancellationToken cancellationToken)
        {
            return await _userOrganisationTableRepository.Get(request.UserOrganisationTableId);
        }
    }
}