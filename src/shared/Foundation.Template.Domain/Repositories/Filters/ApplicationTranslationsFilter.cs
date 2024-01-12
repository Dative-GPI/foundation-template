using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class ApplicationTranslationsFilter
    {
        public Guid ApplicationId { get; set; }
        public string Prefix { get; set; }
        public string LanguageCode { get; set; }
        public IEnumerable<string> Codes { get; set; }
    }
}