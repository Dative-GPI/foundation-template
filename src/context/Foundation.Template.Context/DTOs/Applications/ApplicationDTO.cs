using System;
using Bones.Repository.Interfaces;

namespace Foundation.Template.Context.DTOs
{
    public class ApplicationDTO: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string AdminHost { get; set; }
        public string ShellHost { get; set; }
        public string AdminJWT { get; set; }
        public bool Disabled { get; set; }
    }
}