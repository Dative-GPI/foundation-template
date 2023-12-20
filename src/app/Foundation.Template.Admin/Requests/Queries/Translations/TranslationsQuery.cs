using System;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.Requests
{
    public class TranslationsQuery : ICoreRequest, IRequest<IEnumerable<Translation>>
    {
        public IEnumerable<string> Authorizations => new string[] { "admin.translation.infos" };
    }
}