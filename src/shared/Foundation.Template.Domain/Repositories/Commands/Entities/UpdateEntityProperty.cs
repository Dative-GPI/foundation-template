using System;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class UpdateEntityProperty
    {
        public required Guid EntityPropertyId { get; set; }
        public required string LabelDefault { get; set; }
    }
}