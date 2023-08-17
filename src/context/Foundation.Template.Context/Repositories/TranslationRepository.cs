using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Foundation.Template.Context.DTOs;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Context.Repositories
{
    public class TranslationRepository : ITranslationRepository
    {
        private BaseApplicationContext _context;
        private DbSet<TranslationDTO> _dbSet;

        public TranslationRepository(BaseApplicationContext context)
        {
            _context = context;
            _dbSet = context.Translations;
        }

        public async Task<IEnumerable<Translation>> GetMany()
        {
            var result = await _dbSet.ToListAsync();
            return result.Select(r => new Translation()
            {
                Id = r.Id,
                Code = r.Code,
                Value = r.ValueDefault
            });
        }
    }
}