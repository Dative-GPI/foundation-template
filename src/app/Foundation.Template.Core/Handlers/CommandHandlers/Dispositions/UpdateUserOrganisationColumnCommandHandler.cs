using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Handlers
{
    public class UpdateUserOrganisationColumnCommandHandler : IMiddleware<UpdateUserOrganisationColumnCommand>
    {
        private IUserOrganisationColumnRepository _userOrganisationColumnRepository;

        public UpdateUserOrganisationColumnCommandHandler(IUserOrganisationColumnRepository userOrganisationColumnRepository)
        {
            _userOrganisationColumnRepository = userOrganisationColumnRepository;
        }

        public async Task HandleAsync(UpdateUserOrganisationColumnCommand command, Func<Task> next, CancellationToken cancellationToken)
        {
            var columns = await _userOrganisationColumnRepository.GetMany(new UserOrganisationColumnFilter()
            {
                UserOrganisationId = command.UserOrganisationId,
                TableId = command.TableId
            });

            await _userOrganisationColumnRepository.RemoveMany(columns.Select(c => c.Id));

            await _userOrganisationColumnRepository.CreateMany(command.Columns.Select(c => new Domain.Repositories.Commands.CreateUserOrganisationColumn()
            {
                UserOrganisationTableId = command.UserOrganisationTableId,
                ColumnId = c.ColumnId,
                Hidden = c.Hidden,
                Index = c.Index,
                Disabled = c.Disabled
            }));
        }
    }
}