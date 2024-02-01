using System;
using System.Collections.Generic;

using Foundation.Clients;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class UpsertPermissionOrganisationTypesCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { "admin.permissionorganisationtype.update" };
        public List<UpsertPermissionOrganisationTypes> PermissionOrganisationTypes { get; set; }
    }

    public class UpsertPermissionOrganisationTypes
    {
        public Guid OrganisationTypeId { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}