using System;
using System.Collections.Generic;

namespace Foundation.Template.Admin.ViewModels
{
    public class PermissionsFilterViewModel
    {
        public string Search { get; set; }
        public Guid? OrganisationTypeId { get; set; }
        public Guid? RoleId { get; set; }
        public IEnumerable<Guid> PermissionIds { get; set; }
    }
}