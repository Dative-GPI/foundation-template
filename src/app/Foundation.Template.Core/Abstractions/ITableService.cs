using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface ITableService
    {
        Task<TableViewModel> GetMany(string tableCode);
        Task Update(string tableCode, UpdateTableViewModel payload);
    }
}