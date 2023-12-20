using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class OrganisationTypePermissionOrganisationsQuery : ICoreRequest, IRequest<IEnumerable<OrganisationTypePermissionOrganisationInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { "admin.permissionorganisationtype.infos" };

        public Guid? OrganisationTypeId { get; set; }
    }
}