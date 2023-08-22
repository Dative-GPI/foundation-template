using System;
using System.Collections.Generic;

using Bones.Repository.Interfaces;
using Foundation.Template.Context.Abstractions;

namespace Foundation.Template.Context.DTOs
{
    public class PermissionOrganisationDTO : IEntity<Guid>, ICodeEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string LabelDefault { get; set; }
        public List<OrganisationTypePermissionDTO> OrganisationTypePermissions { get; set; }
        public List<RoleOrganisationPermissionDTO> RoleOrganisationPermissions { get; set; }
        public List<TranslationPermissionDTO> Translations { get; set; }
        public bool Disabled { get; set; }
    }

    public class TranslationPermissionDTO
    {
        public string LanguageCode { get; set; }
        public string Label { get; set; }
    }
}
