using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IRoutesProvider
    {
        Task<IEnumerable<RouteInfos>> GetRoutes();
    }
}