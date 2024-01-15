using System;
using System.Collections.Generic;

using Bones.Flow;
using Foundation.Clients;

using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin.Requests
{
    public class UpdateApplicationTranslationCommand : ICoreRequest, IRequest
    {
        public IEnumerable<string> Authorizations => new[] { "admin.application-translation.update" };

        public string Code { get; set; }
        public IEnumerable<UpdateApplicationTranslationLanguageCommand> Translations { get; set; }
    }

    public class UpdateApplicationTranslationLanguageCommand
    {
        public string LanguageCode { get; set; }
        public string Value { get; set; }
    }
}