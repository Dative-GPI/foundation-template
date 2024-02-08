using System;
using Bones.Repository.Interfaces;
using Foundation.Template.Context.Abstractions;

namespace Foundation.Template.Context.DTOs
{
    // Représente les différentes tables côté front
    public class TableDTO : IEntity<Guid>, ICodeEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string LabelDefault { get; set; }

        public string EntityType { get; set; }
        
        public bool Disabled { get; set; }
    }
}