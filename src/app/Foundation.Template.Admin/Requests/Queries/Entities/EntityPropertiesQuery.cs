using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class EntityPropertiesQuery : ICoreRequest, IRequest<IEnumerable<EntityProperty>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>(); /* new[] {  "admin.entity-property.infos" }; */

        public string Prefix { get; set; }
    }
}