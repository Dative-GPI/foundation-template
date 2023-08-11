using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Domain.Abstractions
{
    public interface ITranslationsProvider
    {
        Task<IEnumerable<ApplicationTranslation>> GetMany(Guid applicationId, string languageCode);
    }
}