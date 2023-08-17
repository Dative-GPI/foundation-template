using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Shell.ViewModels;

namespace Foundation.Template.Shell.Abstractions
{
    public interface IActionService
    {
        Task<IEnumerable<ActionInfosViewModel>> GetMany(ActionsFilterViewModel filter);
    }
}
