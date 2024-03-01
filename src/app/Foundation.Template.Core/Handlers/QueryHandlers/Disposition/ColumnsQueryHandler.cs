using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Handlers
{
    public class ColumnsQueryHandler : IMiddleware<ColumnsQuery, IEnumerable<Column>>
    {
        private ITableRepository _tableRepository;
        private IColumnRepository _columnRepository;

        public ColumnsQueryHandler
        (
            ITableRepository tableRepository,
            IColumnRepository columnRepository
        )
        {
            _tableRepository = tableRepository;
            _columnRepository = columnRepository;
        }

        public Task<IEnumerable<Column>> HandleAsync(ColumnsQuery request, Func<Task<IEnumerable<Column>>> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}