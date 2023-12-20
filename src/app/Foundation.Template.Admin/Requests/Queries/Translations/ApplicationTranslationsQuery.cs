using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.Requests
{
    public class ApplicationTranslationsQuery : ICoreRequest, IRequest<IEnumerable<ApplicationTranslation>>
    {
        public IEnumerable<string> Authorizations => new string[] { "admin.application-translation.infos" };
    }
}