using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class PermissionCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionCategory>>
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_PERMISSION_CATEGORY };
    }
}