using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.AdminAuthorizations;

namespace Foundation.Template.Admin
{
    public class EntityPropertyTranslationsQuery : ICoreRequest, IRequest<IEnumerable<EntityPropertyTranslation>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_ENTITYPROPERTYTRANSLATIONS_INFOS };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public string Prefix { get; set; }
        public Guid? EntityPropertyId { get; set; }
    }
}