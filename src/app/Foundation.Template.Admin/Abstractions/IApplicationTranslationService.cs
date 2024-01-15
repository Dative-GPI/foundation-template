using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IApplicationTranslationService
    {
        Task<IEnumerable<ApplicationTranslationViewModel>> GetMany(TranslationsFilterViewModel filter);
        Task<IEnumerable<ApplicationTranslationViewModel>> Update(string code, UpdateApplicationTranslationViewModel payload);
        Task Download(Stream file);
        Task<IEnumerable<ApplicationTranslationViewModel>> Upload(IEnumerable<ApplicationTranslationsColumnViewModel> languagesCodes, Stream file);
    }
}