using System;

namespace Foundation.Template.Domain.Repositories.Commands
{
    public class CreateApplication
    {
        public Guid ApplicationId { get; set; }   
        public string CoreHost { get; set; }
        public string AdminHost { get; set; }
        public string AdminJWT { get; set; }
    }
}