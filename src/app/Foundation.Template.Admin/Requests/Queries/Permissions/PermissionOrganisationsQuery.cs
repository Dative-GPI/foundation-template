using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.AdminAuthorizations;

namespace Foundation.Template.Admin
{
    public class PermissionOrganisationsQuery : ICoreRequest, IRequest<IEnumerable<PermissionOrganisationInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_PERMISSION_INFOS };

        public string Search { get; set; }
    }
}