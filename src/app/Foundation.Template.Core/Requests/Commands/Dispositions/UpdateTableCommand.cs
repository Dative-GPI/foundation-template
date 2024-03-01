using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class UpdateTableCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>(); /* new[] { CORE_TABLE_UPDATE }; */
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid TableId { get; set; }

        public List<UpdateColumn> Columns { get; set; }
    }

    public class UpdateColumn
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public bool Hidden { get; set; }
        public bool Sortable { get; set; }
        public bool Filterable { get; set; }
        public bool Configurable { get; set; }
        public bool Disabled { get; set; }
    }
}