using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetMany(TablesFilter filter);
        Task<Table> Get(Guid id);
        Task<Table> Find(string code);
    }
}