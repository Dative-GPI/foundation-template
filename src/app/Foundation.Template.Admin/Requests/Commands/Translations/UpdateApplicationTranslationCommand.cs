using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin.Requests
{
    public class UpdateApplicationTranslationCommand : ICoreRequest, IRequest
    {
        public IEnumerable<string> Authorizations => new[] { AdminAuthorizations.ADMIN_APPLICATIONTRANSLATION_UPDATE };

        public List<UpdateApplicationTranslation> ApplicationTranslations { get; set; }
    }

    public class UpdateApplicationTranslation
    {
        public string LanguageCode { get; set; }
        public string Value { get; set; }
        public string TranslationCode { get; set; }
    }
}