using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Domain.Enums;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class PatchTableCommandHandler : IMiddleware<PatchTableCommand>
    {
        private ITableRepository _tableRepository;
        private IColumnRepository _columnRepository;
        private IEntityPropertyRepository _entityPropertyRepository;

        public PatchTableCommandHandler(
            ITableRepository tableRepository,
            IColumnRepository columnRepository,
            IEntityPropertyRepository entityPropertyRepository)
        {
            _tableRepository = tableRepository;
            _columnRepository = columnRepository;
            _entityPropertyRepository = entityPropertyRepository;
        }

        public async Task HandleAsync(PatchTableCommand command, Func<Task> next, CancellationToken cancellationToken)
        {
            var table = await _tableRepository.Get(command.TableId);

            var columns = await _columnRepository.GetMany(new ColumnsFilter()
            {
                ApplicationId = command.ApplicationId,
                TableId = command.TableId
            });

            var entityProperties = await _entityPropertyRepository.GetMany(new EntityPropertiesFilter()
            {
                EntityType = table.EntityType
            });

            var missingEntityProperty = entityProperties
                .ExceptBy(
                    columns.Where(c => c.EntityPropertyId.HasValue).Select(c => c.EntityPropertyId.Value),
                    ep => ep.Id)
                .ToList();

            var index = columns.Any() ? columns.Max(c => c.Index) + 1 : 0;

            await _columnRepository.CreateRange(missingEntityProperty.Select((p, i) => new CreateColumn()
            {
                ApplicationId = command.ApplicationId,
                TableId = command.TableId,

                PropertyType = PropertyType.EntityProperty,
                EntityPropertyId = p.Id,
                CustomPropertyId = null,

                Filterable = false,
                Sortable = false,

                Index = index + i,
                Hidden = false,
                Disabled = true
            }));
        }
    }
}