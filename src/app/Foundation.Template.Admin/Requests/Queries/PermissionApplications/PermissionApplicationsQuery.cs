using System;
using System.Linq;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class PermissionApplicationsQuery : ICoreRequest, IRequest<IEnumerable<PermissionApplicationInfos>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();

        public string Search { get; set; }
    }
}