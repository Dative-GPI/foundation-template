using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation.Template.Domain.Models;
using Foundation.Template.Core.Abstractions;

namespace XXXXX.Core.Kernel.Services
{
    public class ActionsProvider : IActionsProvider
    {
        public Task<IEnumerable<ActionInfos>> GetActions(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}