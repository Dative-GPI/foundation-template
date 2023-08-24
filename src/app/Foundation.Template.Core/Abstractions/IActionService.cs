using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IActionService
    {
        Task<IEnumerable<ActionInfosViewModel>> GetMany(ActionsFilterViewModel filter);
    }
}
