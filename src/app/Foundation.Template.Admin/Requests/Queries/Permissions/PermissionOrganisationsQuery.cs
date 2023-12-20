using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class PermissionOrganisationsQuery : ICoreRequest, IRequest<IEnumerable<PermissionOrganisationInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { "admin.permissions.infos" };

        public string Search { get; set; }
    }
}