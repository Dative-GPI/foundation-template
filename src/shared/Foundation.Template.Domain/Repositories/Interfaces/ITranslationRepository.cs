using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface ITranslationRepository
    {
        Task<IEnumerable<Translation>> GetMany();
    }
}