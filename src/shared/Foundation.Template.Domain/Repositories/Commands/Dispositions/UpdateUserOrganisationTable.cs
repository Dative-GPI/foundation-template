using System;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class UpdateUserOrganisationTable
    {
        public required Guid Id { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int RowsPerPage { get; set; }
        public required bool Disabled { get; set; }
    }
}