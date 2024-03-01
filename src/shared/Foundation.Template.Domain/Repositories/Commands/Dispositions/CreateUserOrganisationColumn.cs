using System;
using System.Collections.Generic;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class CreateUserOrganisationColumn
    {
        public Guid ColumnId { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public bool Hidden { get; set; }
        public int Index { get; set; }
        public required bool Disabled { get; set; }
    }
}