using System;

namespace Foundation.Template.Domain.Models
{
    public class TranslationRoute : ITranslation
    {
        public string LanguageCode { get; set; }
        public string DrawerLabel { get; set; }
    }
}