using System;

namespace Foundation.Template.Admin.ViewModels
{
    public class OrganisationTypePermissionOrganisationInfosViewModel
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; }
        public Guid OrganisationTypeId { get; set; }
    }
}