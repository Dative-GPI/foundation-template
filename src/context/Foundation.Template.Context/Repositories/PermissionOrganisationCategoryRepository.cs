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
    public class PermissionOrganisationCategoryRepository : IPermissionOrganisationCategoryRepository
    {
        private DbSet<PermissionOrganisationCategoryDTO> _categorySet;

        public PermissionOrganisationCategoryRepository(BaseApplicationContext context)
        {
            _categorySet = context.PermissionCategories;
        }

        public async Task<IEnumerable<PermissionCategory>> GetMany()
        {
            var dtos = await _categorySet.AsNoTracking().ToListAsync();

            return dtos.Select(c => new PermissionCategory()
            {
                Label = c.LabelDefault,
                Prefix = c.Prefix,
                Translations = c.Translations?.Select(t => new TranslationPermissionCategory()
                {
                    Label = t.Label,
                    LanguageCode = t.LanguageCode
                }).ToList() ?? new List<TranslationPermissionCategory>()
            }).ToList();
        }
    }
}