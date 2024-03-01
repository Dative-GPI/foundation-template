using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;
using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Models;
using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class PatchTableCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();  /* new[] { ADMIN_TABLE_PATCH }; */
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid TableId { get; set; }
    }
}