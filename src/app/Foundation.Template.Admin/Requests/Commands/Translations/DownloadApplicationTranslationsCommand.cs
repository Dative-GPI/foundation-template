using System;
using System.Collections.Generic;
using System.IO;
using Bones.Flow;



namespace Foundation.Template.Admin.Requests
{
    public class DownloadApplicationTranslationsCommand : ICoreRequest, IRequest
    {
        public IEnumerable<string> Authorizations => new[] { "admin.application-translation.infos" };

        public required Guid ApplicationId { get; set; }

        public required Stream File { get; set; }
    }
}