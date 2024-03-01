using System;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class UserOrganisationTableFilter
    {
        public Guid? UserOrganisationId { get; set; }
        public Guid? TableId { get; set; }
    }
}