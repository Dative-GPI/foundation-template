using System;

namespace Foundation.Template.Domain.Models
{
    public class ApplicationDetails
    {
        public Guid Id { get; set; }
        public string CoreHost { get; set; }
        public string AdminHost { get; set; }
        public string AdminJWT { get; set; }
        public bool Disabled { get; set; }
    }
}