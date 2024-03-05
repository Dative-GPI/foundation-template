using System;
using System.Collections.Generic;

namespace Foundation.Template.Domain.Models
{
    public class UserOrganisationDisposition
    {

        public UserOrganisationTable Table { get; set; }

        public List<UserOrganisationColumn> Columns { get; set; }
    }
}