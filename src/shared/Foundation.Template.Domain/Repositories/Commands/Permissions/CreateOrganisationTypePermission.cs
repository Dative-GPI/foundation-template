using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class CreateOrganisationTypePermission
    {
        public Guid OrganisationTypeId { get; set; }
        public Guid PermissionId { get; set; }
    }
}