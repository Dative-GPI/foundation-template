using System;
using Foundation.Template.Domain.Enums;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class CreateFile
    {
        public string Label { get; set; }
        public Scope Scope { get; set; }
        public Guid? OrganisationId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ApplicationId { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
    }
}