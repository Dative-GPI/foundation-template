using System;
using System.Collections.Generic;

namespace Foundation.Template.Core.ViewModels
{
    public class UpdateUserOrganisationColumnViewModel
    {
        public Guid Id { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public Guid UserOrganisationId { get; set; }
        public Guid TableId { get; set; }

        public List<UpdateUserColumnViewModel> Columns { get; set; }
    }

    public class UpdateUserColumnViewModel
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public bool Hidden { get; set; }
        public int Index { get; set; }
        public bool Disabled { get; set; }
    }
}