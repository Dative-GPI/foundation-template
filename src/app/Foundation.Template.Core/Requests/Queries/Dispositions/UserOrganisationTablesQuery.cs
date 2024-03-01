using System;
using System.Collections.Generic;
using System.Linq;
using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.CoreAuthorizations;

namespace Foundation.Template.Core
{
    public class UserOrganisationTablesQuery : ICoreRequest, IRequest<IEnumerable<UserOrganisationTable>>
    {
        public IEnumerable<string> Authorizations => Enumerable.Empty<string>();
        public Guid TableId { get; set; }
        public Guid UserOrganisationId { get; set; }
        public string Mode { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int RowsPerPage { get; set; }
        public bool Disabled { get; set; }
    }
}