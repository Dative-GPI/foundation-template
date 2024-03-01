using System;
using System.Collections.Generic;

namespace Foundation.Template.Core.ViewModels
{
    public class UserOrganisationTableFilterViewModel
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public Guid UserOrganisationId { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int RowsPerPage { get; set; }

    }
}