using System;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class ColumnsFilter
    {
        public Guid ApplicationId { get; set; }
        public Guid? TableId { get; set; }
    }
}