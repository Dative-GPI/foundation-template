using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Shell.Abstractions
{
    public interface IActionsProvider
    {
        Task<IEnumerable<ActionInfos>> GetActions(string path);
    }
}