using System;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class CreateUserOrganisationTable
    {
        public required Guid TableId { get; set; }
        public required Guid UserOrganisationId { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int RowsPerPage { get; set; }
        public required bool Disabled { get; set; }
    }
}