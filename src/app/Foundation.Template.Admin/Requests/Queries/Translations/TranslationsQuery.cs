using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

using static Foundation.Clients.AdminAuthorizations;


namespace Foundation.Template.Admin.Requests
{
    public class TranslationsQuery : ICoreRequest, IRequest<IEnumerable<Translation>>
    {
        public IEnumerable<string> Authorizations => new string[] { ADMIN_TRANSLATION_INFOS };
    }
}