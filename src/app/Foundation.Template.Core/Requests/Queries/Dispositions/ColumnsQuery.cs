using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class ColumnsQuery : ICoreRequest, IRequest<IEnumerable<Column>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>(); /*new[] { ADMIN_COLUMN_INFOS };*/
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public string TableCode { get; set; }
    }
}