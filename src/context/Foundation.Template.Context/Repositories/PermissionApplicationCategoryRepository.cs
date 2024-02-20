using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Foundation.Template.Context.DTOs;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Context.Repositories
{
    public class PermissionApplicationCategoryRepository : IPermissionApplicationCategoryRepository
    {
        private DbSet<PermissionApplicationCategoryDTO> _categorySet;

        public PermissionApplicationCategoryRepository(BaseApplicationContext context)
        {
            _categorySet = context.PermissionApplicationCategories;
        }

        public async Task<IEnumerable<PermissionApplicationCategory>> GetMany()
        {
            var dtos = await _categorySet.AsNoTracking().ToListAsync();

            return dtos.Select(c => new PermissionApplicationCategory()
            {
                Label = c.LabelDefault,
                Prefix = c.Prefix,
                Translations = c.Translations?.Select(t => new TranslationPermissionApplicationCategory()
                {
                    Label = t.Label,
                    LanguageCode = t.LanguageCode
                }).ToList() ?? new List<TranslationPermissionApplicationCategory>()
            }).ToList();
        }
    }
}