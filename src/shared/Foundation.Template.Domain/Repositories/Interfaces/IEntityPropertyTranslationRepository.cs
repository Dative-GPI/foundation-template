using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IEntityPropertyTranslationRepository
    {
        Task<IEnumerable<EntityPropertyTranslation>> GetMany(EntityPropertyTranslationsFilter filter);
        Task CreateRange(IEnumerable<CreateEntityPropertyTranslation> payload);
        Task RemoveRange(IEnumerable<Guid> ids);
    }
}