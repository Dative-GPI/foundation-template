using System;
using System.Collections.Generic;

namespace Foundation.Extension.Domain.Models
{
    public class UserOrganisationColumn
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
        public Column Column { get; set; }
        public Guid UserOrganisationTableId { get; set; }
        public UserOrganisationTable UserOrganisationTable { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public bool Hidden { get; set; }
        public int Index { get; set; }
        public bool Filterable { get; set; }
        public bool Sortable { get; set; }
        public bool Disabled { get; set; }

        public List<TranslationColumn> Translations { get; set; }
    }
}