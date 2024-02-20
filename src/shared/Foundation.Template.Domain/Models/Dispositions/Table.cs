using System;

namespace Foundation.Template.Domain.Models
{
    public class Table
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public string EntityType { get; set; }
    }
}