using System;
using System.Collections.Generic;
using Foundation.Extension.Domain.Models;

namespace Foundation.Extension.Domain.Repositories.Commands
{
    public class CreateUserOrganisationColumn
    {
        public Guid ColumnId { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public bool Hidden { get; set; }
        public int Index { get; set; }

        public bool Sortable { get; set; }
        public bool Filterable { get; set; }

        public required bool Disabled { get; set; }
    }
}