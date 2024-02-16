using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Template.Domain.Models;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class OrganisationTypeTableQuery : ICoreRequest, IRequest<OrganisationTypeTableDetails>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_COLUMNORGANISATIONTYPE_INFOS };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid OrganisationTypeId { get; set; }
        public Guid TableId { get; set; }
    }
}