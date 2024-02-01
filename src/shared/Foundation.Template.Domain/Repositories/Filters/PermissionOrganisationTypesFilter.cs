using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Repositories.Filters
{
    public class PermissionOrganisationTypesFilter
    {
        public Guid? OrganisationTypeId { get; set;  }
        public IEnumerable<Guid> OrganisationTypeIds { get; set;  }
    }
}