using System;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class UserOrganisationTablesFilter
    {
        public Guid? UserOrganisationId { get; set; }
        public Guid? TableId { get; set; }
    }
}