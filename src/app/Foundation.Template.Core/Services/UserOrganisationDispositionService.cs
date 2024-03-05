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
    public class UserOrganisationDispositionService : IUserOrganisationDispositionService
    {
        private IQueryHandler<UserOrganisationDispositionsQuery, UserOrganisationDisposition> _userOrganisationDispositionQueryHandler;
        private ICommandHandler<UpdateUserOrganisationDispositionCommand> _updateUserOrganisationDispositionCommandHandler;
        private IUserOrganisationTableRepository _userOrganisationTableRepository;
        private IUserOrganisationColumnRepository _userOrganisationColumnRepository;
        private IMapper _mapper;

        public UserOrganisationDispositionService
        (
            IQueryHandler<UserOrganisationDispositionsQuery, UserOrganisationDisposition> userOrganisationDispositionQueryHandler,
            ICommandHandler<UpdateUserOrganisationDispositionCommand> updateUserOrganisationDispositionCommandHandler,
            IUserOrganisationTableRepository userOrganisationTableRepository,
            IUserOrganisationColumnRepository userOrganisationColumnRepository,
            IMapper mapper
        )
        {
            _userOrganisationDispositionQueryHandler = userOrganisationDispositionQueryHandler;
            _updateUserOrganisationDispositionCommandHandler = updateUserOrganisationDispositionCommandHandler;
            _userOrganisationTableRepository = userOrganisationTableRepository;
            _userOrganisationColumnRepository = userOrganisationColumnRepository;
            _mapper = mapper;
        }

        public async Task<UserOrganisationDispositionViewModel> GetMany(string tableCode)
        {
            var query = new UserOrganisationDispositionsQuery()
            {
                TableCode = tableCode
            };

            var result = await _userOrganisationDispositionQueryHandler.HandleAsync(query);

            return _mapper.Map<UserOrganisationDisposition, UserOrganisationDispositionViewModel>(result);
        }

        public async Task Update(string tableCode, UpdateUserOrganisationDispositionViewModel payload)
        {
            var command = new UpdateUserOrganisationDispositionCommand()
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

            await _updateUserOrganisationDispositionCommandHandler.HandleAsync(command);
        }
    }
}