using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Interfaces;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Admin.Requests;

namespace Foundation.Template.Admin.Services
{
    public class TranslationService : ITranslationService
    {
        private IQueryHandler<TranslationsQuery, IEnumerable<Translation>> _translationsQueryHandler;
        private IMapper _mapper;

        public TranslationService(
            IQueryHandler<TranslationsQuery, IEnumerable<Translation>> translationsQueryHandler,
            IMapper mapper
        )
        {
            _translationsQueryHandler = translationsQueryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TranslationViewModel>> GetMany()
        {
            var query = new TranslationsQuery();

            var result = await _translationsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<Translation>, IEnumerable<TranslationViewModel>>(result);
        }
    }
}