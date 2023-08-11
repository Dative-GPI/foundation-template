using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.Requests;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class ApplicationTranslationsQueryHandler: IMiddleware<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>>
    {
        private readonly IRequestContextProvider _requestContextProvider;
        private readonly IApplicationTranslationRepository _applicationTranslationRepository;

        public ApplicationTranslationsQueryHandler(
            IRequestContextProvider requestContextProvider,
            IApplicationTranslationRepository applicationTranslationRepository
        )
        {
            _requestContextProvider = requestContextProvider;
            _applicationTranslationRepository = applicationTranslationRepository;    
        }

        public async Task<IEnumerable<ApplicationTranslation>> HandleAsync(ApplicationTranslationsQuery request, Func<Task<IEnumerable<ApplicationTranslation>>> next, CancellationToken cancellationToken)
        {
            var context = _requestContextProvider.Context;

            var filter  = new ApplicationTranslationFilter() {
                ApplicationId = context.ApplicationId
            };

            var result = await _applicationTranslationRepository.GetMany(filter);

            return result;
        }
    }
}