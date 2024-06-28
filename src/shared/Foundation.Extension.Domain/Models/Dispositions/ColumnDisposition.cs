using System;
using System.Collections.Generic;

namespace Foundation.Extension.Domain.Models
{
    public class ColumnDisposition : ITranslatable<TranslationColumn>
    {
        public Guid ColumnId { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }
        public bool Hidden { get; set; }
        public bool Sortable { get; set; }
        public bool Filterable { get; set; }
        public bool Configurable { get; set; }

        #region Translated properties
        public string Label { get; set; }
        #endregion
        
        public List<TranslationColumn> Translations { get; set; }
    }
}