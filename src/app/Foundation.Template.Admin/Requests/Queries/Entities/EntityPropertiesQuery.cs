using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.AdminAuthorizations;

namespace Foundation.Template.Admin
{
    public class EntityPropertiesQuery : ICoreRequest, IRequest<IEnumerable<EntityProperty>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_ENTITYPROPERTY_INFOS };

        public string Prefix { get; set; }
    }
}