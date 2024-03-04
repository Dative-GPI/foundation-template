using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface ITableService
    {
        Task<ApplicationTableDetailsViewModel> Get(Guid tableId);
    }
}