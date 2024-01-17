using System;
using System.Collections.Generic;

namespace Foundation.Template.Admin.ViewModels
{
    public class UpdateApplicationTranslationViewModel
    {
        public IEnumerable<UpdateApplicationTranslationLanguageViewModel> Translations { get; set; }
    }

    public class UpdateApplicationTranslationLanguageViewModel
    {
        public string LanguageCode { get; set; }
        public string Value { get; set; }
    }
}