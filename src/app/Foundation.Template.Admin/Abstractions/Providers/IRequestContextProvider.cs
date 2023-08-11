using Foundation.Template.Admin.Models;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IRequestContextProvider
    {
        RequestContext Context { get; }
    }
}