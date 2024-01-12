using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IApplicationTranslationRepository
    {
        Task<ApplicationTranslation> Get(Guid translationId);
        Task<IEnumerable<ApplicationTranslation>> GetMany(ApplicationTranslationsFilter filter);
        Task CreateRange(IEnumerable<CreateApplicationTranslation> payload);
        Task RemoveRange(IEnumerable<Guid> translationIds);
    }
}