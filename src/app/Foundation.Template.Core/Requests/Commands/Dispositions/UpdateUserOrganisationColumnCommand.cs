using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class UpdateUserOrganisationColumnCommand : ICoreRequest
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();

        public Guid UserOrganisationTableId { get; set; }
        public Guid TableId { get; set; }
        public Guid UserOrganisationId { get; set; }

        public List<UpdateUserColumn> Columns { get; set; }
    }

    public class UpdateUserColumn
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public bool Hidden { get; set; }
        public int Index { get; set; }
        public bool Disabled { get; set; }
    }
}