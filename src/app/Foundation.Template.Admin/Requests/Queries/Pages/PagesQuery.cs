using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.AdminAuthorizations;

namespace Foundation.Template.Admin
{
    public class PagesQuery : ICoreRequest, IRequest<IEnumerable<Page>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_LAYOUTPAGE_DETAILS };
    }
}