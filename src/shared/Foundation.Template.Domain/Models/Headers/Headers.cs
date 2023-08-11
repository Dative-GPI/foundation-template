using System;

namespace Foundation.Template.Domain.Models
{
    public class Headers
    {
        public Guid ApplicationId { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid ActorId { get; set; }
        public string LanguageCode { get; set; }
        public Guid? ExtensionId { get; set; }
    }
}