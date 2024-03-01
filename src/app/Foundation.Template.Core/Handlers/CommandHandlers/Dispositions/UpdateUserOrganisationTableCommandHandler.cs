using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Handlers
{
    public class UpdateUserOrganisationTableCommandHandler : IMiddleware<UpdateUserOrganisationTableCommand>
    {
        private IUserOrganisationTableRepository _userOrganisationTableRepository;

        public UpdateUserOrganisationTableCommandHandler(IUserOrganisationTableRepository userOrganisationTableRepository)
        {
            _userOrganisationTableRepository = userOrganisationTableRepository;
        }

        public async Task HandleAsync(UpdateUserOrganisationTableCommand command, Func<Task> next, CancellationToken cancellationToken)
        {
            var updateTable = new Domain.Repositories.Commands.UpdateUserOrganisationTable()
            {
                Id = command.Id,
                Mode = command.Mode,
                SortBy = command.SortBy,
                SortOrder = command.SortOrder,
                RowsPerPage = command.RowsPerPage,
                Disabled = command.Disabled
            };

            await _userOrganisationTableRepository.Update(updateTable);
        }
    }
}