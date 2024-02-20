using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class UpdateRolePermissionOrganisation
    {
        public Guid Id { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}