using System;

namespace Foundation.Template.Gateway.ViewModels
{
    public class ApplicationDetailsViewModel
    {
        public Guid Id { get; set; }
        public string AdminHost { get; set; }
        public string ShellHost { get; set; }
    }
}