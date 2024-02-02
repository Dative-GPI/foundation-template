using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class UpdateRoleApplication
    {
        public Guid Id { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}