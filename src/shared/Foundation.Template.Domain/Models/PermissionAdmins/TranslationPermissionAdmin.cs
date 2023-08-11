using System;

namespace Foundation.Template.Domain.Models
{
    public class TranslationPermissionAdmin : ITranslation
    {
        public string LanguageCode { get; set; }
        public string Label { get; set; }
    }
}