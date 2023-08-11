using System;

namespace Foundation.Template.Gateway.ViewModels
{
    public class CreateApplicationViewModel
    {
        public Guid ApplicationId { get; set; }
        public string AdminHost { get; set; }
        public string ShellHost { get; set; }
        public string AdminJWT { get; set; }
    }
}