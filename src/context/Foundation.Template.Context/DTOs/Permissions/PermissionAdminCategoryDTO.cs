using System;
using System.Collections.Generic;
using Bones.Repository.Interfaces;
using Foundation.Template.Context.Abstractions;

namespace Foundation.Template.Context.DTOs
{
    public class PermissionAdminCategoryDTO : IEntity<Guid>, ICodeEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string LabelDefault { get; set; }
        public string Prefix { get; set; }
        public List<TranslationPermissionAdminCategoryDTO> Translations { get; set; }
        public bool Disabled { get; set; }
    }

    public class TranslationPermissionAdminCategoryDTO
    {
        public string LanguageCode { get; set; }
        public string Label { get; set; }
    }
}