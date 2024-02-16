using System;
using System.Collections.Generic;
using Bones.Repository.Interfaces;
using Foundation.Template.Context.Abstractions;
using Foundation.Template.Domain.Enums;
namespace Foundation.Template.Context.DTOs
{
    // permet de gérer les colonnes désactivées
    // et les actions possibles pour chaque colonne par application
    public class ColumnDTO : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public ApplicationDTO Application { get; set; }

        public Guid TableId { get; set; }
        public TableDTO Table { get; set; }

        public PropertyType PropertyType { get; set; }

        public Guid? EntityPropertyId { get; set; }
        public EntityPropertyDTO EntityProperty { get; set; }

        public bool Sortable { get; set; }
        public bool Filterable { get; set; }

        public bool Hidden { get; set; }
        public int Index { get; set; }
        public bool Disabled { get; set; }
    }
}