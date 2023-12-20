using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin
{
    public class PermissionOrganisationCategoriesQuery : ICoreRequest, IRequest<IEnumerable<PermissionOrganisationCategory>>
    {
        public IEnumerable<string> Authorizations => new[] { "admin.permission.category" };
    }
}