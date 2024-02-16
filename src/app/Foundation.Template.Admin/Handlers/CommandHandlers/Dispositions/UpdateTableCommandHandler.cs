using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class UpdateTableCommandHandler : IMiddleware<UpdateTableCommand>
    {
        private IColumnRepository _columnRepository;

        public UpdateTableCommandHandler(IColumnRepository columnRepository)
        {
            _columnRepository = columnRepository;
        }

        public async Task HandleAsync(UpdateTableCommand command, Func<Task> next, CancellationToken cancellationToken)
        {
            var updateColumns = command.Columns.Select(c => new Domain.Repositories.Commands.UpdateColumn()
            {
                Id = c.Id,
                Index = c.Index,
                Configurable = c.Configurable,
                Filterable = c.Filterable,
                Sortable = c.Sortable,
                Hidden = c.Hidden,
                Disabled = c.Disabled
            });

            await _columnRepository.UpdateRange(updateColumns);
        }
    }
}