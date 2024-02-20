using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Models
{
    public class OrganisationTypeTableInfos
    {
        public Guid OrganisationTypeId { get; set; }
        public Guid TableId { get; set; }
        public List<OrganisationTypeDisposition> Dispositions { get; set; }
    }
}