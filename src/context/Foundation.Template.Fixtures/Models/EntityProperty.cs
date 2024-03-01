using Foundation.Template.Context.Abstractions;

namespace Foundation.Template.Fixtures
{
    public class EntityProperty : ICodeEntity
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public string EntityType { get; set; }
        public string LabelDefault { get; set; }

        public string ParentCode { get; set; }
    }
}