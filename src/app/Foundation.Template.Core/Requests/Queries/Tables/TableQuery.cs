using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class TableQuery : IRequest<UserTable>, ICoreRequest
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();
        public string TableCode { get; set; }
    }
}