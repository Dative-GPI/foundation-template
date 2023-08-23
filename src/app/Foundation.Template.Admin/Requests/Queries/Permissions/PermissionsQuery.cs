using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class PermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_PERMISSION_INFOS };

        public string Search { get; set; }
    }
}