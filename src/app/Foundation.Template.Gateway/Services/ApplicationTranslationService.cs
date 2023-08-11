using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Gateway.Abstractions;
using Foundation.Template.Gateway.ViewModels;

namespace Foundation.Template.Gateway.Services
{
    public class ApplicationTranslationService : IApplicationTranslationService
    {
        private IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> _applicationTranslationsQueryHandler;
        private IMapper _mapper;

        public ApplicationTranslationService(
            IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> applicationTranslationsQueryHandler,
            IMapper mapper
        )
        {
            _applicationTranslationsQueryHandler = applicationTranslationsQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationTranslationViewModel>> GetMany()
        {
            var query = new ApplicationTranslationsQuery();

            var result = await _applicationTranslationsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<ApplicationTranslation>, IEnumerable<ApplicationTranslationViewModel>>(result);
        }
    }
}