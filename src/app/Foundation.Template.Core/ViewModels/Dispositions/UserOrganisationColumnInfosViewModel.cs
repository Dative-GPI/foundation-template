using System;
using System.Collections.Generic;

namespace Foundation.Template.Core.ViewModels
{
    public class UserOrganisationColumnInfosViewModel
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public bool Hidden { get; set; }
        public int Index { get; set; }
        public bool Disabled { get; set; }
    }
}