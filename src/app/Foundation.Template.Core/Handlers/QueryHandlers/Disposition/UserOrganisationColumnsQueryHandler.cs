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
    public class UserOrganisationColumnsQueryHandler : IMiddleware<UserOrganisationColumnsQuery, IEnumerable<UserOrganisationColumn>>
    {

        private readonly IUserOrganisationColumnRepository _userOrganisationColumnRepository;

        public UserOrganisationColumnsQueryHandler(IUserOrganisationColumnRepository userOrganisationColumnRepository)
        {
            _userOrganisationColumnRepository = userOrganisationColumnRepository;
        }

        public async Task<IEnumerable<UserOrganisationColumn>> HandleAsync(UserOrganisationColumnsQuery request, Func<Task<IEnumerable<UserOrganisationColumn>>> next, CancellationToken cancellationToken)
        {
            return await _userOrganisationColumnRepository.GetMany(new UserOrganisationColumnFilter()
            {
                UserOrganisationId = request.UserOrganisationId,
                TableId = request.TableId,
                UserOrganisationTableId = request.UserOrganisationTableId
            });
        }
    }
}