using System;

using Bones.Repository.Interfaces;


namespace Foundation.Template.Context.DTOs
{
    public class PageDTO : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string LabelDefault { get; set; }
        public bool Disabled { get; set; }
  }
}