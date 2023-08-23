using System;
using System.Linq;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class PermissionAdminsQuery : ICoreRequest, IRequest<IEnumerable<PermissionAdminInfos>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();

        public string Search { get; set; }
    }
}