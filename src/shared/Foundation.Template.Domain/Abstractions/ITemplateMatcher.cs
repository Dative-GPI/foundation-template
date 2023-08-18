using System.Collections.Generic;

namespace Foundation.Template.Domain.Abstractions
{
    public interface ITemplateMatcher
    {
        bool TryMatch(string template, string value, out Dictionary<string, string> result, Dictionary<string, string> defaults = null);
    }
}