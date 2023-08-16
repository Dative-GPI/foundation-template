using System;
using System.Linq;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Shell
{
    public class PermissionsQuery : ICoreRequest, IRequest<IEnumerable<PermissionInfos>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();
    }
}