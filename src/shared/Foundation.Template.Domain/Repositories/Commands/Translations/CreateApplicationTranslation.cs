using System;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class CreateApplicationTranslation
    {
        public Guid ApplicationId { get; set; }
        public string LanguageCode { get; set; }
        public Guid TranslationId { get; set; }
        public string Value { get; set; }
    }
}