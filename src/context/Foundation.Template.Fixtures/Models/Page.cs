using System;
using Foundation.Template.Context.Abstractions;

namespace Foundation.Template.Fixtures
{
    public class Page : ICodeEntity
    {
        public string Code { get; set; }
        public string LabelDefault { get; set; }
        public bool ShowOnDrawer { get; set; }
    }
}