using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class UserOrganisationColumnsQuery : ICoreRequest, IRequest<IEnumerable<UserOrganisationColumn>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();
        public Guid UserOrganisationId { get; set; }
        public Guid TableId { get; set; }
        public Guid UserOrganisationTableId { get; set; }
    }
}