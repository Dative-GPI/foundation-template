using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class PermissionAdminFilter
    {
        public string Search { get; set; }
        public IEnumerable<Guid> PermissionAdminIds { get; set; }
    }
}