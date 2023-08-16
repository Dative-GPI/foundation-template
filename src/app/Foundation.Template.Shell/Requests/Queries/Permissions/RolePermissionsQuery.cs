using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Clients;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Shell
{
    public class RoleOrganisationQuery : ICoreRequest, IRequest<RoleOrganisationDetails>
    {
        public IEnumerable<string> Authorizations => new[] { ShellAuthorizations.APP_PERMISSIONROLE_INFOS };
        
        public Guid RoleOrganisationId { get; set; }
    }
}