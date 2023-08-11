using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Models
{
    public class PermissionAdminCategory: ITranslatable<TranslationPermissionAdminCategory>
    {
        public string Label { get; set; }
        public string Prefix { get; set; }
        public List<TranslationPermissionAdminCategory> Translations { get; set; }
    }

    public class TranslationPermissionAdminCategory: ITranslation
    {
        public string LanguageCode { get; set; }
        public string Label { get; set; }
    }
}