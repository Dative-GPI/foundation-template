using System;
using System.Collections.Generic;

using Foundation.Clients;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class UpsertOrganisationTypePermissionsCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_PERMISSIONORGANISATIONTYPE_UPDATE };
        public List<UpsertOrganisationTypePermissions> OrganisationTypePermissions { get; set; }
    }

    public class UpsertOrganisationTypePermissions
    {
        public Guid OrganisationTypeId { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}