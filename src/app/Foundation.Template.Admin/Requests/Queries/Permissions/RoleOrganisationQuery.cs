using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class RoleOrganisationQuery : ICoreRequest, IRequest<RoleOrganisationDetails>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_ORGANISATION_TYPE_ROLE_INFOS };
        
        public Guid RoleOrganisationId { get; set; }
    }
}