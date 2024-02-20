using System;
using System.IO;
using System.Collections.Generic;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class UploadEntityPropertyTranslationsCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { "admin.application-translation.update" };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public required List<SpreadsheetColumnDefinition> Labels { get; set; }
        public required List<SpreadsheetColumnDefinition> Categories { get; set; }
        public required Stream File { get; set; }
    }
}