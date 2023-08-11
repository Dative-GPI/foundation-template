using Foundation.Template.Gateway.Models;

namespace Foundation.Template.Gateway.Abstractions
{
    public interface IRequestContextProvider
    {
        RequestContext Context { get; }
    }
}