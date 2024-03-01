using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class UserOrganisationTableQuery : ICoreRequest, IRequest<UserOrganisationTable>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();
        public Guid UserOrganisationTableId { get; set; }
    }
}