using System;

namespace Foundation.Template.Gateway.ViewModels
{
    public class CreateApplicationViewModel
    {
        public Guid ApplicationId { get; set; }
        public string AdminHost { get; set; }
        public string CoreHost { get; set; }
        public string AdminJWT { get; set; }
    }
}