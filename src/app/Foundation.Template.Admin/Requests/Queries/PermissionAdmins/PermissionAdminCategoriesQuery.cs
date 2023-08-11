using System;
using System.Linq;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class PermissionAdminCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionAdminCategory>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();
    }
}