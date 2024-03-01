using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;
using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class OrganisationTypeTableQuery : ICoreRequest, IRequest<OrganisationTypeTableDetails>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();  /* new[] { ADMIN_COLUMNORGANISATIONTYPE_INFOS }; */
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid OrganisationTypeId { get; set; }
        public Guid TableId { get; set; }
    }
}