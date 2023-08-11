using System;
using System.Collections.Generic;
using System.Text.Json;
using Bones.Flow;
using Bones.Repository.Interfaces;
using Foundation.Clients;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class UpdateRoleOrganisationCommand : ICoreRequest, IRequest<IEntity<Guid>>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_ORGANISATION_TYPE_ROLE_UPDATE };

        public Guid RoleOrganisationId { get; set; }
        public List<Guid> PermissionIds { get; set; }
        public Dictionary<string, JsonElement> ExtensionData { get; set; }
    }
}