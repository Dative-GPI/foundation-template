using System.Threading.Tasks;

using Foundation.Template.Core.Models;

namespace Foundation.Template.Core.Abstractions
{
    public interface IRequestContextProvider
    {
        RequestContext Context { get; }
    }
}