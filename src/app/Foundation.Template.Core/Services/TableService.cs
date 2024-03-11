using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;


namespace Foundation.Template.Core.Services
{
    public class TableService : ITableService
    {
        private IQueryHandler<TableQuery, UserTable> _tableQueryHandler;
        private ICommandHandler<UpdateTableCommand> _updateTableCommandHandler;
        private IMapper _mapper;

        public TableService
        (
            IQueryHandler<TableQuery, UserTable> tableQueryHandler,
            ICommandHandler<UpdateTableCommand> updateTableCommandHandler,
            IMapper mapper
        )
        {
            _tableQueryHandler = tableQueryHandler;
            _updateTableCommandHandler = updateTableCommandHandler;
            _mapper = mapper;
        }

        public async Task<TableViewModel> GetMany(string tableCode)
        {
            var query = new TableQuery()
            {
                TableCode = tableCode
            };

            var result = await _tableQueryHandler.HandleAsync(query);

            return _mapper.Map<UserTable, TableViewModel>(result);
        }

        public async Task Update(string tableCode, UpdateTableViewModel payload)
        {
            var command = new UpdateTableCommand()
            {
                TableCode = tableCode,
                Mode = payload.Mode,
                SortBy = payload.SortBy,
                SortOrder = payload.SortOrder,
                RowsPerPage = payload.RowsPerPage,
                Columns = payload.Columns.Select(c => new UpdateUserOrganisationColumnCommand()
                {
                    ColumnId = c.ColumnId,
                    Index = c.Index,
                    Hidden = c.Hidden,
                    Sortable = c.Sortable,
                    Filterable = c.Filterable
                })
            };

            await _updateTableCommandHandler.HandleAsync(command);
        }
    }
}