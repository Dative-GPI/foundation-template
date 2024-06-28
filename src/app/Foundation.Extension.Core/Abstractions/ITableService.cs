using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Extension.Core.ViewModels;

namespace Foundation.Extension.Core.Abstractions
{
    public interface ITableService
    {
        Task<TableViewModel> GetMany(string tableCode);
        Task Update(string tableCode, UpdateTableViewModel payload);
    }
}