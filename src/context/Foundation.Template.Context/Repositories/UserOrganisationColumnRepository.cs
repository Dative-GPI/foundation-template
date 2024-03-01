using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Repositories.Interfaces;
using Foundation.Template.Context.DTOs;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Context.Repositories
{
    public class UserOrganisationColumnRepository : IUserOrganisationColumnRepository
    {
        private DbSet<UserOrganisationColumnDTO> _dbSet;
        private BaseApplicationContext _context;

        public UserOrganisationColumnRepository(BaseApplicationContext context)
        {
            _dbSet = context.UserOrganisationColumns;
            _context = context;
        }

        public Task Create(CreateUserOrganisationColumn payload)
        {
            var dto = new UserOrganisationColumnDTO()
            {
                Id = Guid.NewGuid(),
                ColumnId = payload.ColumnId,
                UserOrganisationTableId = payload.UserOrganisationTableId,
                Hidden = payload.Hidden,
                Index = payload.Index,
                Disabled = payload.Disabled
            };

            _dbSet.Add(dto);

            return Task.FromResult<IEntity<Guid>>(dto);
        }

        public Task CreateMany(IEnumerable<CreateUserOrganisationColumn> payload)
        {
            _dbSet.AddRange(
                payload.Select(p => new UserOrganisationColumnDTO()
                {
                    Id = Guid.NewGuid(),
                    ColumnId = p.ColumnId,
                    UserOrganisationTableId = p.UserOrganisationTableId,
                    Hidden = p.Hidden,
                    Index = p.Index,
                    Disabled = p.Disabled,
                })
            );

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<UserOrganisationColumn>> GetMany(UserOrganisationColumnFilter filter)
        {
            IQueryable<UserOrganisationColumnDTO> set = _dbSet.Include(c => c.Column).Include(c => c.Column.EntityProperty).Include(t => t.UserOrganisationTable);

            if (filter.UserOrganisationTableId.HasValue)
            {
                set = set.Where(s => s.UserOrganisationTableId == filter.UserOrganisationTableId.Value);
            }

            if (filter.TableId.HasValue)
            {
                set = set.Where(s => s.UserOrganisationTable.TableId == filter.TableId.Value);
            }

            if (filter.UserOrganisationId.HasValue)
            {
                set = set.Where(s => s.UserOrganisationTable.UserOrganisationId == filter.UserOrganisationId.Value);
            }

            var result = await set.AsNoTracking().ToListAsync();

            return result.Select(r => new UserOrganisationColumn()
            {
                Id = r.Id,
                ColumnId = r.ColumnId,
                Column = new Column()
                {
                    Id = r.Column.Id,
                    EntityPropertyId = r.Column.EntityPropertyId,
                    TableId = r.Column.TableId,
                    Code = r.Column.EntityProperty.Code,
                    Value = r.Column.EntityProperty.Value,
                    Label = r.Column.EntityProperty.LabelDefault,
                    Sortable = r.Column.Sortable,
                    Filterable = r.Column.Filterable,
                    Hidden = r.Column.Hidden,
                    Index = r.Column.Index,
                    Disabled = r.Column.Disabled,
                },
                UserOrganisationTableId = r.UserOrganisationTableId,
                Hidden = r.Hidden,
                Index = r.Index,
                Disabled = r.Disabled,
            });
        }

        public async Task Remove(Guid id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
            _dbSet.Remove(entity);
        }

        public async Task RemoveMany(IEnumerable<Guid> ids)
        {
            var entities = await _dbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
            _dbSet.RemoveRange(entities);
        }
    }
}