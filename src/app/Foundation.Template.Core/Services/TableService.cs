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
        private IQueryHandler<TablesQuery, UserTable> _TableQueryHandler;
        private ICommandHandler<UpdateTableCommand> _updateTableCommandHandler;
        private IUserOrganisationTableRepository _userOrganisationTableRepository;
        private IUserOrganisationColumnRepository _userOrganisationColumnRepository;
        private IMapper _mapper;

        public TableService
        (
            IQueryHandler<TablesQuery, UserTable> TableQueryHandler,
            ICommandHandler<UpdateTableCommand> updateTableCommandHandler,
            IUserOrganisationTableRepository userOrganisationTableRepository,
            IUserOrganisationColumnRepository userOrganisationColumnRepository,
            IMapper mapper
        )
        {
            _TableQueryHandler = TableQueryHandler;
            _updateTableCommandHandler = updateTableCommandHandler;
            _userOrganisationTableRepository = userOrganisationTableRepository;
            _userOrganisationColumnRepository = userOrganisationColumnRepository;
            _mapper = mapper;
        }

        public async Task<TableViewModel> GetMany(string tableCode)
        {
            var query = new TablesQuery()
            {
                TableCode = tableCode
            };

            var result = await _TableQueryHandler.HandleAsync(query);

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