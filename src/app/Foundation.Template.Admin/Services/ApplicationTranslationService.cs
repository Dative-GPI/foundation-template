using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Admin.Requests;
using System.Linq;

namespace Foundation.Template.Admin.Services
{
    public class ApplicationTranslationService : IApplicationTranslationService
    {
        private IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> _applicationTranslationsQueryHandler;
        private ICommandHandler<UpdateApplicationTranslationCommand> _updateApplicationTranslationsCommandHandler;
        private IMapper _mapper;

        public ApplicationTranslationService(
            IQueryHandler<ApplicationTranslationsQuery, IEnumerable<ApplicationTranslation>> applicationTranslationsQueryHandler,
            ICommandHandler<UpdateApplicationTranslationCommand> updateApplicationTranslationsCommandHandler,
            IMapper mapper
        )
        {
            _applicationTranslationsQueryHandler = applicationTranslationsQueryHandler;
            _updateApplicationTranslationsCommandHandler = updateApplicationTranslationsCommandHandler;
            _mapper = mapper;
        }

        public async Task UpdateRange(IEnumerable<UpdateApplicationTranslationViewModel> payload)
        {
            var command = new UpdateApplicationTranslationCommand()
            {
                ApplicationTranslations = payload.Select(tr => new UpdateApplicationTranslation()
                {
                    LanguageCode = tr.LanguageCode,
                    TranslationCode = tr.TranslationCode,
                    Value = tr.Value
                }).ToList()
            };

            await _updateApplicationTranslationsCommandHandler.HandleAsync(command);
        }

        public async Task<IEnumerable<ApplicationTranslationViewModel>> GetMany()
        {
            var query = new ApplicationTranslationsQuery()
            {
            };

            var results = await _applicationTranslationsQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<ApplicationTranslation>, IEnumerable<ApplicationTranslationViewModel>>(results);
        }
    }
}