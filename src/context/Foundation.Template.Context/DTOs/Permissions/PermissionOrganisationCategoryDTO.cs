using System;
using System.Collections.Generic;
using Bones.Repository.Interfaces;

namespace Foundation.Template.Context.DTOs
{
    public class PermissionOrganisationCategoryDTO : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string LabelDefault { get; set; }
        public string Prefix { get; set; }
        public List<TranslationPermissionCategoryDTO> Translations { get; set; }
        public bool Disabled { get; set; }
    }

    public class TranslationPermissionCategoryDTO
    {
        public string LanguageCode { get; set; }
        public string Label { get; set; }
    }
}