using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Extension.Domain.Models;
using Foundation.Extension.Domain.Repositories.Filters;
using Foundation.Extension.Domain.Repositories.Interfaces;
using Foundation.Extension.Core.Abstractions;
using Foundation.Extension.Core.Models;
using Foundation.Extension.Domain.Enums;
using Foundation.Extension.Domain.Repositories.Commands;

namespace Foundation.Extension.Core.Handlers
{
    public class UpdateTableCommandHandler : IMiddleware<UpdateTableCommand>
    {
        private RequestContext _context;
        private ITableRepository _tableRepository;
        private IUserOrganisationTableRepository _userOrganisationTableRepository;
        private IUserOrganisationColumnRepository _userOrganisationColumnRepository;

        public UpdateTableCommandHandler
        (
            IRequestContextProvider requestContextProvider,
            ITableRepository tableRepository,
            IUserOrganisationTableRepository userOrganisationTableRepository,
            IUserOrganisationColumnRepository userOrganisationColumnRepository
        )
        {
            _context = requestContextProvider.Context;
            _tableRepository = tableRepository;
            _userOrganisationTableRepository = userOrganisationTableRepository;
            _userOrganisationColumnRepository = userOrganisationColumnRepository;
        }

        public async Task HandleAsync(UpdateTableCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var table = await _tableRepository.Find(request.TableCode);

            if (table == null)
            {
                throw new Exception(ErrorCode.EntityNotFound);
            }

            var userOrganisationTables = await _userOrganisationTableRepository.GetMany(new UserOrganisationTablesFilter()
            {
                TableId = table.Id,
                UserOrganisationId = _context.ActorOrganisationId.Value
            });

            var userOrganisationColumns = await _userOrganisationColumnRepository.GetMany(new UserOrganisationColumnsFilter()
            {
                TableId = table.Id,
                UserOrganisationId = _context.ActorOrganisationId.Value
            });

            await _userOrganisationColumnRepository.RemoveMany(userOrganisationColumns.Select(c => c.Id));

            await _userOrganisationTableRepository.Remove(userOrganisationTables.SingleOrDefault().Id);

            var newUserOrganisationTable = await _userOrganisationTableRepository.Create(new CreateUserOrganisationTable()
            {
                TableId = table.Id,
                UserOrganisationId = _context.ActorOrganisationId.Value,
                Mode = request.Mode,
                SortBy = request.SortBy,
                SortOrder = request.SortOrder,
                RowsPerPage = request.RowsPerPage,
                Disabled = false
            });

            await _userOrganisationColumnRepository.CreateMany(request.Columns.Select(c => new CreateUserOrganisationColumn()
            {
                UserOrganisationTableId = newUserOrganisationTable.Id,
                ColumnId = c.ColumnId,
                Index = c.Index,
                Hidden = c.Hidden,
                Sortable = c.Sortable,
                Filterable = c.Filterable,
                Disabled = false
            }));
        }
    }
}