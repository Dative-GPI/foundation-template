using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class UpdateRoleOrganisation
    {
        public Guid Id { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}