using Foundation.Template.Context.Abstractions;

namespace Foundation.Template.Fixtures
{
    public class Fixture : ICodeEntity
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }
}