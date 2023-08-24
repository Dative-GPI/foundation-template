using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteInfosViewModel>> GetMany();
    }
}
