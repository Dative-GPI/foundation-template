using System;
using System.Linq;
using System.Threading.Tasks;
using Foundation.Template.Core.Abstractions;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Providers
{
    public class ApplicationTableProvider : IApplicationTableProvider
    {
        private IRequestContextProvider _requestContextProvider;
        private ITableRepository _tableRepository;
        private IColumnRepository _columnRepository;

        public ApplicationTableProvider(IRequestContextProvider requestContextProvider,
            ITableRepository tableRepository,
            IColumnRepository columnRepository)
        {
            _requestContextProvider = requestContextProvider;
            _tableRepository = tableRepository;
            _columnRepository = columnRepository;
        }

        public async Task<ApplicationTableDetails> Get(Guid tableId)
        {
            var context = _requestContextProvider.Context;
            var table = await _tableRepository.Get(tableId);
            var columns = await _columnRepository.GetMany(new ColumnsFilter()
            {
                ApplicationId = context.ApplicationId,
                TableId = tableId
            });

            return new ApplicationTableDetails()
            {
                Id = table.Id,
                Code = table.Code,
                EntityType = table.EntityType,
                Label = table.Label,
                Columns = columns.ToList()

            };
        }
    }
}