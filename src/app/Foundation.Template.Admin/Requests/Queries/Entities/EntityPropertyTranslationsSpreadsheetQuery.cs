using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class EntityPropertyTranslationsSpreadsheetQuery : ICoreRequest, IRequest<byte[]>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>(); /* new[] { "admin.entity-property.infos", "admin.entity-property-translations.infos" }; */
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
    }
}