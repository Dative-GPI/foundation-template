using System.Threading.Tasks;

using Foundation.Template.Shell.Models;

namespace Foundation.Template.Shell.Abstractions
{
    public interface IRequestContextProvider
    {
        RequestContext Context { get; }
    }
}