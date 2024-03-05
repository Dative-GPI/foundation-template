using System;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class UserOrganisationColumnsFilter
    {
        public Guid? UserOrganisationId { get; set; }
        public Guid? UserOrganisationTableId { get; set; }
        public Guid? TableId { get; set; }
    }
}