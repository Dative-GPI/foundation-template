using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.AdminAuthorizations;

namespace Foundation.Template.Admin
{
    public class PermissionOrganisationTypesQuery : ICoreRequest, IRequest<IEnumerable<PermissionOrganisationTypeInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_PERMISSIONORGANISATIONTYPE_INFOS };

        public Guid? OrganisationTypeId { get; set; }
    }
}