using System;
using System.Collections.Generic;

namespace Foundation.Template.Core.ViewModels
{
    public class OrganisationTypeDispositionViewModel
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
        public int Index { get; set; }
        public bool Hidden { get; set; }
        public bool Disabled { get; set; }
    }
}