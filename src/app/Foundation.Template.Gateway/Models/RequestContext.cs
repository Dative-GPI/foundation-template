using System;

namespace Foundation.Template.Gateway.Models
{
    public class RequestContext
    {
        public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public string LanguageCode { get; set; }
        public string Jwt { get; set; }
    }
}