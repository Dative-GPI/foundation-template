using System;

using Bones.Repository.Interfaces;

namespace Foundation.Template.Context.DTOs
{
    public class RoleOrganisationPermissionDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }
        public Guid RoleOrganisationId { get; set; }
        public Guid PermissionOrganisationId { get; set; }
        public PermissionOrganisationDTO PermissionOrganisation { get; set; }
        public bool Disabled { get; set; }
    }
}