using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IEntityPropertyRepository
    {
        Task<EntityProperty> Get(Guid id);
        Task<IEnumerable<EntityProperty>> GetMany(EntityPropertiesFilter filter);
    }
}