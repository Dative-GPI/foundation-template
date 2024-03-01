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
    public class UserOrganisationTablesQueryHandler : IMiddleware<UserOrganisationTablesQuery, IEnumerable<UserOrganisationTable>>
    {

        private readonly IUserOrganisationTableRepository _userOrganisationTableRepository;

        public UserOrganisationTablesQueryHandler(IUserOrganisationTableRepository userOrganisationTableRepository)
        {
            _userOrganisationTableRepository = userOrganisationTableRepository;
        }

        public async Task<IEnumerable<UserOrganisationTable>> HandleAsync(UserOrganisationTablesQuery request, Func<Task<IEnumerable<UserOrganisationTable>>> next, CancellationToken cancellationToken)
        {
            return await _userOrganisationTableRepository.GetMany(new UserOrganisationTableFilter()
            {
                UserOrganisationId = request.UserOrganisationId,
                TableId = request.TableId
            });
        }
    }
}