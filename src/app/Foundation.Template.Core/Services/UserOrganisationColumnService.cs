using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bones.Flow;
using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;
using Foundation.Template.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Foundation.Template.Core.Services
{
    public class UserOrganisationColumnService : IUserOrganisationColumnService
    {

        private readonly ILogger<UserOrganisationColumnService> _logger;
        private readonly IQueryHandler<UserOrganisationColumnsQuery, IEnumerable<UserOrganisationColumn>> _userOrganisationColumnsQueryHandler;
        private readonly ICommandHandler<UpdateUserOrganisationColumnCommand> _updateUserOrganisationColumnCommandHandler;
        private readonly IMapper _mapper;

        public UserOrganisationColumnService(ILogger<UserOrganisationColumnService> logger,
            IQueryHandler<UserOrganisationColumnsQuery, IEnumerable<UserOrganisationColumn>> userOrganisationColumnsQueryHandler,
            ICommandHandler<UpdateUserOrganisationColumnCommand> updateUserOrganisationColumnCommandHandler,
            IMapper mapper)
        {
            _logger = logger;
            _userOrganisationColumnsQueryHandler = userOrganisationColumnsQueryHandler;
            _updateUserOrganisationColumnCommandHandler = updateUserOrganisationColumnCommandHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserOrganisationColumnInfosViewModel>> GetMany(UserOrganisationColumnFilterViewModel filter)
        {

            var query = new UserOrganisationColumnsQuery
            {
                UserOrganisationId = filter.UserOrganisationId,
                TableId = filter.TableId,
                UserOrganisationTableId = filter.UserOrganisationTableId
            };
            var result = await _userOrganisationColumnsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<UserOrganisationColumn>, IEnumerable<UserOrganisationColumnInfosViewModel>>(result);

        }

        public async Task Update(UpdateUserOrganisationColumnViewModel payload)
        {
            var command = new UpdateUserOrganisationColumnCommand
            {
                UserOrganisationId = payload.UserOrganisationId,
                TableId = payload.TableId,
                UserOrganisationTableId = payload.UserOrganisationTableId,
                Columns = payload.Columns.Select(c => new UpdateUserColumn
                {
                    Id = c.Id,
                    ColumnId = c.ColumnId,
                    UserOrganisationTableId = c.UserOrganisationTableId,
                    Hidden = c.Hidden,
                    Index = c.Index,
                    Disabled = c.Disabled
                }).ToList()
            };

            await _updateUserOrganisationColumnCommandHandler.HandleAsync(command);
        }
    }
}
