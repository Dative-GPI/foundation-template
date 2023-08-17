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
    public class PermissionAdminCategoryRepository : IPermissionAdminCategoryRepository
    {
        private DbSet<PermissionAdminCategoryDTO> _categorySet;

        public PermissionAdminCategoryRepository(BaseApplicationContext context)
        {
            _categorySet = context.PermissionAdminCategories;
        }

        public async Task<IEnumerable<PermissionAdminCategory>> GetMany()
        {
            var dtos = await _categorySet.AsNoTracking().ToListAsync();

            return dtos.Select(c => new PermissionAdminCategory()
            {
                Label = c.LabelDefault,
                Prefix = c.Prefix,
                Translations = c.Translations?.Select(t => new TranslationPermissionAdminCategory()
                {
                    Label = t.Label,
                    LanguageCode = t.LanguageCode
                }).ToList() ?? new List<TranslationPermissionAdminCategory>()
            }).ToList();
        }
    }
}