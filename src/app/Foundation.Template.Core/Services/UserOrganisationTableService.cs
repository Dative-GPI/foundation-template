using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bones.Flow;
using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;
using Foundation.Template.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Foundation.Template.Core.Services
{
    public class UserOrganisationTableService : IUserOrganisationTableService
    {

        private readonly ILogger<UserOrganisationTableService> _logger;
        private readonly IQueryHandler<UserOrganisationTablesQuery, IEnumerable<UserOrganisationTable>> _userOrganisationTablesQueryHandler;
        private readonly IQueryHandler<UserOrganisationTableQuery, UserOrganisationTable> _userOrganisationTableQueryHandler;
        private readonly ICommandHandler<UpdateUserOrganisationTableCommand> _updateUserOrganisationTableCommandHandler;
        private readonly IMapper _mapper;

        public UserOrganisationTableService(ILogger<UserOrganisationTableService> logger,
            IQueryHandler<UserOrganisationTablesQuery, IEnumerable<UserOrganisationTable>> userOrganisationTablesQueryHandler,
            IQueryHandler<UserOrganisationTableQuery, UserOrganisationTable> userOrganisationTableQueryHandler,
            ICommandHandler<UpdateUserOrganisationTableCommand> updateUserOrganisationTableCommandHandler,
            IMapper mapper)
        {
            _logger = logger;
            _userOrganisationTablesQueryHandler = userOrganisationTablesQueryHandler;
            _userOrganisationTableQueryHandler = userOrganisationTableQueryHandler;
            _updateUserOrganisationTableCommandHandler = updateUserOrganisationTableCommandHandler;
            _mapper = mapper;
        }


        public async Task<UserOrganisationTableDetailsViewModel> Get(Guid userOrganisationTableId)
        {
            var query = new UserOrganisationTableQuery
            {
                UserOrganisationTableId = userOrganisationTableId
            };
            var result = await _userOrganisationTableQueryHandler.HandleAsync(query);

            return _mapper.Map<UserOrganisationTable, UserOrganisationTableDetailsViewModel>(result);
        }

        public async Task<IEnumerable<UserOrganisationTableInfosViewModel>> GetMany(UserOrganisationTableFilterViewModel filter)
        {
            var query = new UserOrganisationTablesQuery
            {
                UserOrganisationId = filter.UserOrganisationId,
                TableId = filter.TableId
            };

            var result = await _userOrganisationTablesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<UserOrganisationTable>, IEnumerable<UserOrganisationTableInfosViewModel>>(result);
        }

        public async Task Update(Guid userOrganisationTableId, UpdateUserOrganisationTableViewModel payload)
        {
            var command = new UpdateUserOrganisationTableCommand
            {
                Id = userOrganisationTableId,
                UserOrganisationId = payload.UserOrganisationId,
                TableId = payload.TableId,
                Mode = payload.Mode,
                SortBy = payload.SortBy,
                SortOrder = payload.SortOrder,
                RowsPerPage = payload.RowsPerPage,
            };

            await _updateUserOrganisationTableCommandHandler.HandleAsync(command);
        }
    }
}
