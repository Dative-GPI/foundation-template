using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class OrganisationTypePermissionsQuery : ICoreRequest, IRequest<IEnumerable<OrganisationTypePermissionInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_PERMISSIONORGANISATIONTYPE_INFOS };
        
        public Guid? OrganisationTypeId { get; set; }
    }
}