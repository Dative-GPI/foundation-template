using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.ViewModels;
using AutoMapper;
using System.Linq;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Services
{
    public class TableService : ITableService
    {
        private readonly IQueryHandler<TableQuery, ApplicationTableDetails> _tableQueryHandler;
        private readonly IRequestContextProvider _requestContextProvider;
        private readonly IApplicationTableProvider _applicationTableProvider;
        private readonly IMapper _mapper;

        public TableService
        (
            IQueryHandler<TableQuery, ApplicationTableDetails> tableQueryHandler,
            IRequestContextProvider requestContextProvider,
            IApplicationTableProvider applicationTableProvider,
            IMapper mapper
        )
        {
            _tableQueryHandler = tableQueryHandler;
            _requestContextProvider = requestContextProvider;
            _applicationTableProvider = applicationTableProvider;
            _mapper = mapper;
        }

        public async Task<ApplicationTableDetailsViewModel> Get(Guid tableId)
        {
            var context = _requestContextProvider.Context;
            var query = new TableQuery()
            {
                ActorId = context.ActorId,
                ApplicationId = context.ApplicationId,
                TableId = tableId
            };

            var result = await _tableQueryHandler.HandleAsync(query);

            return _mapper.Map<ApplicationTableDetails, ApplicationTableDetailsViewModel>(result);
        }
    }
}