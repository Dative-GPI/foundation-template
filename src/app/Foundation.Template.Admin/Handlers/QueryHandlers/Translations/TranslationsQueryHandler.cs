using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Admin.Requests;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class TranslationsQueryHandler: IMiddleware<TranslationsQuery, IEnumerable<Translation>>
    {
        private readonly ITranslationRepository _translationRepository;

        public TranslationsQueryHandler(
            ITranslationRepository translationRepository
        )
        {
            _translationRepository = translationRepository;    
        }

        public async Task<IEnumerable<Translation>> HandleAsync(TranslationsQuery request, Func<Task<IEnumerable<Translation>>> next, CancellationToken cancellationToken)
        {
            return await _translationRepository.GetMany();
        }
    }
}