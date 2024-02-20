using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Models
{
    public class RolePermissionOrganisationDetails
    {
        public Guid Id { get; set; }
        public List<PermissionItem> Permissions { get; set; }
    }
}