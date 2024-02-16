using System;
using System.Threading.Tasks;
using Foundation.Template.Admin.Models;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IApplicationTableProvider
    {
        Task<ApplicationTableDetails> Get(Guid tableId);
    }
}