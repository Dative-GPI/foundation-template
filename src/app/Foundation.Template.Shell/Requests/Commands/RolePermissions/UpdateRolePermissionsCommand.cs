using System;
using System.Collections.Generic;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Foundation.Clients;

namespace Foundation.Template.Shell
{
    public class UpdateRoleOrganisationCommand : ICoreRequest, IRequest<IEntity<Guid>>
    {
        public IEnumerable<string> Authorizations => new[] { ShellAuthorizations.APP_PERMISSIONROLE_UPDATE };

        public Guid RoleOrganisationId { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}