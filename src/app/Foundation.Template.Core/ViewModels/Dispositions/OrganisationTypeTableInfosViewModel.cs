using System;
using System.Collections;
using System.Collections.Generic;

namespace Foundation.Template.Core.ViewModels
{
    public class OrganisationTypeTableInfosViewModel
    {
        public Guid OrganisationTypeId { get; set; }
        public Guid TableId { get; set; }
        public List<OrganisationTypeDispositionViewModel> Dispositions { get; set; }
    }
}