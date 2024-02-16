using System;

namespace Foundation.Template.Domain.Models
{
    public class UserOrganisationDisposition
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public Guid ColumnId { get; set; }
        public int Index { get; set; }
        public bool Hidden { get; set; }
    }
}