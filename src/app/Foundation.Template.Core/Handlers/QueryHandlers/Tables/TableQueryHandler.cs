using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;
using Foundation.Template.Core.Abstractions;
using Foundation.Template.Core.Models;
using Foundation.Template.Domain.Enums;

namespace Foundation.Template.Core.Handlers
{
    public class TableQueryHandler : IMiddleware<TableQuery, UserTable>
    {
        private RequestContext _context;
        private ITableRepository _tableRepository;
        private IColumnRepository _columnRepository;
        private IEntityPropertyTranslationRepository _entityPropertyTranslationRepository;
        private IOrganisationTypeDispositionRepository _organisationTypeDispositionRepository;
        private IUserOrganisationTableRepository _userOrganisationTableRepository;
        private IUserOrganisationColumnRepository _userOrganisationColumnRepository;

        public TableQueryHandler
        (
            IRequestContextProvider requestContextProvider,
            ITableRepository tableRepository,
            IColumnRepository columnRepository,
            IEntityPropertyTranslationRepository entityPropertyTranslationRepository,
            IOrganisationTypeDispositionRepository organisationTypeDispositionRepository,
            IUserOrganisationTableRepository userOrganisationTableRepository,
            IUserOrganisationColumnRepository userOrganisationColumnRepository)
        {
            _context = requestContextProvider.Context;

            _tableRepository = tableRepository;
            _columnRepository = columnRepository;

            _entityPropertyTranslationRepository = entityPropertyTranslationRepository;

            _organisationTypeDispositionRepository = organisationTypeDispositionRepository;
            _userOrganisationTableRepository = userOrganisationTableRepository;
            _userOrganisationColumnRepository = userOrganisationColumnRepository;
        }

        public async Task<UserTable> HandleAsync(TableQuery request, Func<Task<UserTable>> next, CancellationToken cancellationToken)
        {
            Table table = await _tableRepository.Find(request.TableCode);

            if (table == null)
            {
                throw new Exception(ErrorCode.EntityNotFound);
            }

            /* var customProperties = await _customPropertyRepository.GetMany(new CustomPropertiesFilter()
            {
                ApplicationId = _context.ApplicationId,
                Entities = table.Entity
            }); */

            //var customPropertyMap = customProperties.ToDictionary(g => g.Id);

            var entityPropertyTranslations = await _entityPropertyTranslationRepository.GetMany(new EntityPropertyTranslationsFilter()
            {
                ApplicationId = _context.ApplicationId,
                EntityType = table.EntityType
            });

            var entityPropertiesMap = entityPropertyTranslations
                            .GroupBy(ep => ep.EntityPropertyId)
                            .ToDictionary(g => g.Key, g => g.ToList());

            var columns = await _columnRepository.GetMany(new ColumnsFilter()
            {
                ApplicationId = _context.ApplicationId,
                TableId = table.Id
            });

            var orgTypeColumnsDisposition = await _organisationTypeDispositionRepository.GetMany(new ColumnOrganisationTypesFilter()
            {
                OrganisationTypeId = _context.OrganisationTypeId.Value,
                TableId = table.Id
            });

            var userOrganisationTables = await _userOrganisationTableRepository.GetMany(new UserOrganisationTablesFilter()
            {
                UserOrganisationId = _context.ActorOrganisationId.Value,
                TableId = table.Id
            });

            var userOrganisationTable = userOrganisationTables.SingleOrDefault();

            var userOrganisationColumns = await _userOrganisationColumnRepository.GetMany(new UserOrganisationColumnsFilter()
            {
                UserOrganisationId = _context.ActorOrganisationId.Value,
                TableId = table.Id
            });

            var translatedColumns = columns
                .Where(c => !c.Disabled)
                .Select(c => new
                {
                    Column = c,
                    Translations = c.PropertyType switch
                    {
                        /* PropertyType.CustomProperty => customPropertyMap.GetValueOrDefault(c.CustomPropertyId.Value)?.Translations.Select(t => new TranslationColumn()
                        {
                            Label = t.Label,
                            LanguageCode = t.LanguageCode
                        }).ToList() ?? new List<TranslationColumn>(), */
                        PropertyType.EntityProperty => entityPropertiesMap.GetValueOrDefault(c.EntityPropertyId.Value)?.Select(t => new TranslationColumn()
                        {
                            Label = t.Label,
                            LanguageCode = t.LanguageCode
                        }).ToList() ?? new List<TranslationColumn>(),
                        _ => new List<TranslationColumn>()
                    }
                })
                .ToList();

            // on join left les appColumns avec les orgTypesColumns et si il y a une disposition de sauvegardé on l'a choisi
            // sinon on garde la config au niveau app
            // ensuite on join left avec les userColumnsDisposition et on fait pareil
            // pas besoin de recalculer les indexs, ça se fera côté front si besoin
            var columnFinals = translatedColumns
                .GroupJoin(orgTypeColumnsDisposition, c => c.Column.Id, c => c.ColumnId, (appC, orgCs) =>
                {
                    var orgC = orgCs.FirstOrDefault();

                    return new UserOrganisationColumn()
                    {
                        Id = appC.Column.Id,
                        Value = appC.Column.Value,
                        Sortable = appC.Column.Sortable,
                        Filterable = appC.Column.Filterable,

                        Index = orgC?.Index ?? appC.Column.Index,
                        Hidden = orgC?.Hidden ?? appC.Column.Hidden,
                        Disabled = orgC?.Disabled ?? appC.Column.Disabled,

                        Translations = appC.Translations,
                        Label = appC.Column.Label
                    };
                })
                .Where(c => !c.Disabled)
                .GroupJoin(userOrganisationColumns, c => c.Id, c => c.ColumnId, (appC, userCs) =>
                {
                    var userC = userCs.FirstOrDefault();
                    return new UserOrganisationColumn()
                    {
                        ColumnId = appC.Id,
                        Value = appC.Value,
                        Sortable = appC.Sortable,
                        Filterable = appC.Filterable,

                        Index = userC?.Index ?? appC.Index,
                        Hidden = userC?.Hidden ?? appC.Hidden,

                        Label = appC.Label,
                        Translations = appC.Translations
                    };
                })
                .ToList();

            return new UserTable()
            {
                Table = userOrganisationTable,
                Columns = columnFinals
            };
        }
    }
}