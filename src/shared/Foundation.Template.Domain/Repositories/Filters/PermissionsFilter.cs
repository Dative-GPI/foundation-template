using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class PermissionsFilter
    {
        public Guid? OrganisationTypeId { get; set; }
        public Guid? RoleId { get; set; }
        public string Search { get; set; }
        public IEnumerable<Guid> PermissionIds { get; set; }
    }
}