using System;

namespace Foundation.Template.Domain.Models
{
    public class UserOrganisationColumn
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
        public Column Column { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public UserOrganisationTable UserOrganisationTable { get; set; }
        public bool Hidden { get; set; }
        public int Index { get; set; }
        public bool Disabled { get; set; }
    }
}