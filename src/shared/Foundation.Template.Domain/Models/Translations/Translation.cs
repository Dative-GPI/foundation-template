using System;

namespace Foundation.Template.Domain.Models
{
    public class Translation
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}