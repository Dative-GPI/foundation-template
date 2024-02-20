using System;
using System.Collections.Generic;

using Bones.Flow;
using Bones.Repository.Interfaces;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class ReplaceEntityPropertyTranslationsCommand : ICoreRequest, IRequest<IEntity<Guid>>
    {
        public IEnumerable<string> Authorizations => new[] { "admin.entity-property-translations.update" };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public required Guid EntityPropertyId { get; set; }
        public required IEnumerable<ReplaceEntityPropertyTranslation> Translations { get; set; }
    }

    public class ReplaceEntityPropertyTranslation
    {
        public string LanguageCode { get; set; }
        public string Label { get; set; }
        public string CategoryLabel { get; set; }
    }
}