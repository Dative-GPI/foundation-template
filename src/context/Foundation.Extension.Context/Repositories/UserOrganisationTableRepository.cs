using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Bones.Repository.Interfaces;
using Foundation.Extension.Domain.Repositories.Interfaces;
using Foundation.Extension.Context.DTOs;
using Foundation.Extension.Domain.Repositories.Commands;
using Foundation.Extension.Domain.Models;
using Foundation.Extension.Domain.Repositories.Filters;

namespace Foundation.Extension.Context.Repositories
{
    public class UserOrganisationTableRepository : IUserOrganisationTableRepository
    {
        private DbSet<UserOrganisationTableDTO> _dbSet;
        private BaseApplicationContext _context;

        public UserOrganisationTableRepository(BaseApplicationContext context)
        {
            _dbSet = context.UserOrganisationTables;
            _context = context;
        }


        public async Task<UserOrganisationTable> Get(Guid id)
        {
            var dto = await _dbSet.SingleOrDefaultAsync(t => t.Id == id);

            return new UserOrganisationTable
            {
                Id = dto.Id,
                TableId = dto.TableId,
                UserOrganisationId = dto.UserOrganisationId,
                Mode = dto.Mode,
                SortBy = dto.SortBy,
                SortOrder = dto.SortOrder,
                RowsPerPage = dto.RowsPerPage,
                Disabled = dto.Disabled
            };
        }

        public async Task<IEnumerable<UserOrganisationTable>> GetMany(UserOrganisationTablesFilter filter)
        {
            IQueryable<UserOrganisationTableDTO> set = _dbSet;

            if (filter.UserOrganisationId.HasValue)
            {
                set = set.Where(s => s.UserOrganisationId == filter.UserOrganisationId.Value);
            }

            if (filter.TableId.HasValue)
            {
                set = set.Where(s => s.TableId == filter.TableId.Value);
            }

            var result = await set.AsNoTracking().ToListAsync();

            return result.Select(r => new UserOrganisationTable()
            {
                Id = r.Id,
                TableId = r.TableId,
                UserOrganisationId = r.UserOrganisationId,
                Mode = r.Mode,
                SortBy = r.SortBy,
                SortOrder = r.SortOrder,
                RowsPerPage = r.RowsPerPage,
                Disabled = r.Disabled,
            });
        }


        public Task<IEntity<Guid>> Create(CreateUserOrganisationTable payload)
        {
            var dto = new UserOrganisationTableDTO()
            {
                Id = Guid.NewGuid(),
                TableId = payload.TableId,
                UserOrganisationId = payload.UserOrganisationId,
                Mode = payload.Mode,
                SortBy = payload.SortBy,
                SortOrder = payload.SortOrder,
                RowsPerPage = payload.RowsPerPage,
                Disabled = payload.Disabled
            };

            var result = _dbSet.Add(dto);

            return Task.FromResult<IEntity<Guid>>(result.Entity);
        }

        public async Task<IEntity<Guid>> Update(UpdateUserOrganisationTable payload)
        {
            var dto = await _dbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == payload.Id);

            if (dto == default)
            {
                return null;
            }

            dto.Mode = payload.Mode;
            dto.SortBy = payload.SortBy;
            dto.SortOrder = payload.SortOrder;
            dto.RowsPerPage = payload.RowsPerPage;

            return _dbSet.Update(dto).Entity;
        }


        public async Task Remove(Guid id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
            _dbSet.Remove(entity);
        }
    }
}