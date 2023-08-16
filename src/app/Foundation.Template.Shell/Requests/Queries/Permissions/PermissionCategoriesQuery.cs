using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Clients;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Shell
{
    public class PermissionCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionCategory>>
    {
        public IEnumerable<string> Authorizations => new string[] {};
    }
}