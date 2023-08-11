using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.Requests;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class UpdateApplicationTranslationsCommandHandler : IMiddleware<UpdateApplicationTranslationCommand>
    {
        private IRequestContextProvider _requestContextProvider;
        private ITranslationRepository _translationRepository;
        private IApplicationTranslationRepository _applicationTranslationRepository;

        public UpdateApplicationTranslationsCommandHandler(
            IRequestContextProvider requestContextProvider,
            ITranslationRepository translationRepository,
            IApplicationTranslationRepository applicationTranslationRepository)
        {
            _requestContextProvider = requestContextProvider;
            _translationRepository = translationRepository;
            _applicationTranslationRepository = applicationTranslationRepository;
        }

        public async Task HandleAsync(UpdateApplicationTranslationCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            var context = _requestContextProvider.Context;
            var translations = await _translationRepository.GetMany();

            var formerTranslations = await _applicationTranslationRepository.GetMany(new ApplicationTranslationFilter()
            {
                ApplicationId = context.ApplicationId
            });

            await _applicationTranslationRepository.RemoveRange(formerTranslations.Select(t => t.Id));

            await _applicationTranslationRepository.CreateRange(
                request.ApplicationTranslations.Join(
                    translations, 
                    t => t.TranslationCode, 
                    t => t.Code, 
                    (req, tr) => new CreateApplicationTranslation()
                    {
                        ApplicationId = context.ApplicationId,
                        LanguageCode = req.LanguageCode,
                        TranslationId = tr.Id,
                        Value = req.Value
                    }
                )
            );
        }
    }
}