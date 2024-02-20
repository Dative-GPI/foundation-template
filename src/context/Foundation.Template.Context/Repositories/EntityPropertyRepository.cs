using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Repositories.Interfaces;
using Foundation.Template.Context.DTOs;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Context;

namespace Foundation.Template.Context.Repositories
{
    public class EntityPropertyRepository : IEntityPropertyRepository
    {
        private readonly DbSet<EntityPropertyDTO> _dbSet;

        public EntityPropertyRepository(BaseApplicationContext context)
        {
            _dbSet = context.EntityProperties;
        }

        public async Task<EntityProperty> Get(Guid id)
        {
            var dto = await _dbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(ep => ep.Id == id);

            if (dto == null) return null;

            return new EntityProperty()
            {
                Id = dto.Id,
                Code = dto.Code,
                LabelDefault = dto.LabelDefault,
                EntityType = dto.EntityType,
                Value = dto.Value,
                Disabled = dto.Disabled
            };
        }

        public async Task<IEnumerable<EntityProperty>> GetMany(EntityPropertiesFilter filter)
        {
            var query = _dbSet
                .AsQueryable();

            if (!String.IsNullOrWhiteSpace(filter.EntityType))
            {
                query = query.Where(ep => ep.EntityType == filter.EntityType);
            }

            var dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(dto => new EntityProperty()
            {
                Id = dto.Id,
                Code = dto.Code,
                LabelDefault = dto.LabelDefault,
                CategoryLabelDefault = dto.CategoryLabelDefault,
                EntityType = dto.EntityType,
                Value = dto.Value,
                Disabled = dto.Disabled
            }).OrderBy(e => e.Code).ToList();
        }
    }
}