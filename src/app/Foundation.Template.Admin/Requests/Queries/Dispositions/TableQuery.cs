using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class TableQuery : ICoreRequest, IRequest<ApplicationTableDetails>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_TABLE_DETAILS };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid TableId { get; set; }
    }
}