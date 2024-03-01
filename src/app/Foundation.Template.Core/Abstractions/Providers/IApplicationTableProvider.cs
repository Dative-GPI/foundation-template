using System;
using System.Threading.Tasks;
using Foundation.Template.Core.Models;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Core.Abstractions
{
    public interface IApplicationTableProvider
    {
        Task<ApplicationTableDetails> Get(Guid tableId);
    }
}