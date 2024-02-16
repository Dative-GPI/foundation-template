using System;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class ColumnOrganisationTypesFilter
    {
        public Guid? OrganisationTypeId { get; set; }
        public Guid? TableId { get; set; }
    }
}