using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class EntityPropertyTranslationsQuery : ICoreRequest, IRequest<IEnumerable<EntityPropertyTranslation>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();/* new[] { "admin.entity-property-translations.infos" }; */
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public string Prefix { get; set; }
        public Guid? EntityPropertyId { get; set; }
    }
}