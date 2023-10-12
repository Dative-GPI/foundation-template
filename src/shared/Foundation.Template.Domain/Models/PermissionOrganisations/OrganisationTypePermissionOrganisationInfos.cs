using System;

namespace Foundation.Template.Domain.Models
{
    public class OrganisationTypePermissionOrganisationInfos
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; }
        public Guid OrganisationTypeId { get; set; }
    }
}