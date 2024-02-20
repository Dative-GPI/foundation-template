using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class TablesQuery : ICoreRequest, IRequest<IEnumerable<ApplicationTableInfos>>
    {
        public IEnumerable<string> Authorizations => new[] { ADMIN_TABLE_INFOS };
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }
    }
}