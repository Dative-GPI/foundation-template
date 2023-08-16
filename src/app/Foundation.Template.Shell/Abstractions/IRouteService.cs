using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Shell.ViewModels;

namespace Foundation.Template.Shell.Interfaces
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteInfosViewModel>> GetMany();
    }
}
