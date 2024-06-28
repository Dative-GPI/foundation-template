using System;
using System.Collections.Generic;

namespace Foundation.Extension.Core.ViewModels
{
    public class TableViewModel
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string TableCode { get; set; }
        public Guid UserOrganisationId { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int RowsPerPage { get; set; }

        public List<UserOrganisationColumnViewModel> Columns { get; set; }
    }

    public class UserOrganisationColumnViewModel
    {
        public Guid ColumnId { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }
        public bool Hidden { get; set; }
        public bool Sortable { get; set; }
        public bool Filterable { get; set; }

        public List<TranslationColumnViewModel> Translations { get; set; }
    }

    public class UserOrganisationTableViewModel
    {
        public Guid Id { get; set; }
        public string TableCode { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int RowsPerPage { get; set; }
    }

    public class TranslationColumnViewModel
    {
        public string LanguageCode { get; set; }
        public string Label { get; set; }
    }
}