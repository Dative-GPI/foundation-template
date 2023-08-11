using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Models
{
    public class RoleAdminDetails
    {
        public Guid Id { get; set; }
        public List<PermissionItem> Permissions { get; set; }
    }
}