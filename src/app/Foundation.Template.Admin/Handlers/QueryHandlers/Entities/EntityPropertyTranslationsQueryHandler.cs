using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class EntityPropertyTranslationsQueryHandler : IMiddleware<EntityPropertyTranslationsQuery, IEnumerable<EntityPropertyTranslation>>
    {
        private IEntityPropertyTranslationRepository _entityPropertyTranslationRepository;

        public EntityPropertyTranslationsQueryHandler(
            IEntityPropertyTranslationRepository entityPropertyTranslationRepository)
        {
            _entityPropertyTranslationRepository = entityPropertyTranslationRepository;
        }

        public Task<IEnumerable<EntityPropertyTranslation>> HandleAsync(EntityPropertyTranslationsQuery request, Func<Task<IEnumerable<EntityPropertyTranslation>>> next, CancellationToken cancellationToken)
        {
            var entityPropertyTranslations = _entityPropertyTranslationRepository.GetMany(new EntityPropertyTranslationsFilter()
            {
                ApplicationId = request.ApplicationId,
                EntityPropertyId = request.EntityPropertyId,
            });

            return entityPropertyTranslations;
        }
    }
}