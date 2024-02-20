using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class ReplaceEntityPropertyTranslationsCommandHandler : IMiddleware<ReplaceEntityPropertyTranslationsCommand>
    {
        private readonly IEntityPropertyRepository _entityPropertyRepository;
        private readonly IEntityPropertyTranslationRepository _applicationEntityPropertyRepository;

        public ReplaceEntityPropertyTranslationsCommandHandler
        (
            IEntityPropertyRepository entityPropertyRepository,
            IEntityPropertyTranslationRepository applicationEntityPropertyRepository
        )
        {
            _entityPropertyRepository = entityPropertyRepository;
            _applicationEntityPropertyRepository = applicationEntityPropertyRepository;
        }

        public async Task HandleAsync(ReplaceEntityPropertyTranslationsCommand command, Func<Task> next, CancellationToken cancellationToken)
        {
            var property = await _entityPropertyRepository.Get(command.EntityPropertyId);

            if (property == default)
            {
                throw new Exception(ErrorCode.EntityNotFound);
            }

            var formerEntityPropertys = await _applicationEntityPropertyRepository.GetMany(new EntityPropertyTranslationsFilter()
            {
                ApplicationId = command.ApplicationId,
                EntityPropertyId = command.EntityPropertyId
            });

            await _applicationEntityPropertyRepository.RemoveRange(formerEntityPropertys.Select(t => t.Id));

            var newEntityPropertys = command.Translations.Select(t => new CreateEntityPropertyTranslation()
            {
                ApplicationId = command.ApplicationId,
                LanguageCode = t.LanguageCode,
                EntityPropertyId = property.Id,

                Label = t.Label,
                CategoryLabel = t.CategoryLabel
            }).ToList();

            await _applicationEntityPropertyRepository.CreateRange(newEntityPropertys);
        }
    }
}
