using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class ColumnsQuery : ICoreRequest, IRequest<IEnumerable<Column>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_COLUMN_INFOS };
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public string TableCode { get; set; }
    }
}