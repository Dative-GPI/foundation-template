using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class UpdateRoleAdmin
    {
        public Guid Id { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}