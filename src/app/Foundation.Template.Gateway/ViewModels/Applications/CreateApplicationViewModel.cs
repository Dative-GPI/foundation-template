using System;

namespace Foundation.Template.Gateway.ViewModels
{
    public class CreateApplicationViewModel
    {
        public Guid ApplicationId { get; set; }
        public string Host { get; set; }
        public string AdminJWT { get; set; }
    }
}