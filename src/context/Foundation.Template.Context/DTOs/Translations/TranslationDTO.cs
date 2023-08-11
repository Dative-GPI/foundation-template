using System;

using Bones.Repository.Interfaces;

namespace Foundation.Template.Context.DTOs
{
    public class TranslationDTO : IEntity<Guid>, IDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string ValueDefault { get; set; }
        public bool Disabled { get; set; }
    }
}