using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class PermissionApplicationFilter
    {
        public string Search { get; set; }
        public IEnumerable<Guid> PermissionApplicationIds { get; set; }
    }
}