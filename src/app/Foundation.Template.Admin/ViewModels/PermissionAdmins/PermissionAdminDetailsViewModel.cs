using System;
using System.Collections.Generic;

namespace Foundation.Template.Admin.ViewModels
{
    public class PermissionAdminDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public List<TranslationPermissionAdminViewModel> Translations { get; set; }
    }
}