using System;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class CreateUserOrganisationDisposition
    {
        public required Guid UserOrganisationId { get; set; }
        public required Guid TableId { get; set; }

        public required Guid ColumnId { get; set; }
        public required int Index { get; set; }
        public required bool Hidden { get; set; }
    }
}