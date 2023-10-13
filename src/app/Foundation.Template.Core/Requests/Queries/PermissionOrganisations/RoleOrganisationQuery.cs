using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Clients;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Core
{
    public class RoleOrganisationQuery : ICoreRequest, IRequest<RoleOrganisationDetails>
    {
        public IEnumerable<string> Authorizations => new[] { CoreAuthorizations.APP_PERMISSIONROLE_INFOS };
        
        public Guid RoleOrganisationId { get; set; }
    }
}