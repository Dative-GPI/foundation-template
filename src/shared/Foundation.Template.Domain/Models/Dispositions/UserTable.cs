using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Models
{
    public class UserTable
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string TableCode { get; set; }
        public Guid UserOrganisationId { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int RowsPerPage { get; set; }
        public bool Disabled { get; set; }

        public List<UserOrganisationColumn> Columns { get; set; }
    }
}