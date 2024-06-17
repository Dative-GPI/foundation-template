using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Foundation.Template.Domain.Repositories.Interfaces;
using Foundation.Template.Context.DTOs;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Context.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly DbSet<PageDTO> _dbSet;

        public PageRepository(BaseApplicationContext context)
        {
            _dbSet = context.Pages;
        }

        public async Task<IEnumerable<Page>> GetMany()
        {
            var query = _dbSet
                .AsQueryable();

            var dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(dto => new Page()
            {
                Id = dto.Id,
                Code = dto.Code,
                LabelDefault = dto.LabelDefault
            }).ToList();
        }
    }
}