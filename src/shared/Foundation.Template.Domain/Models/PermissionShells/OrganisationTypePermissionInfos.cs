using System;

namespace Foundation.Template.Domain.Models
{
    public class OrganisationTypePermissionInfos
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; }
    }
}