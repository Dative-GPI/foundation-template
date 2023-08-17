using System;
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
    public class PermissionAdminRepository : IPermissionAdminRepository
    {
        private DbSet<PermissionAdminDTO> _dbSet;

        public PermissionAdminRepository(BaseApplicationContext context)
        {
            _dbSet = context.PermissionAdmins;
        }

        public async Task<IEnumerable<PermissionAdminInfos>> GetMany(PermissionAdminFilter filter)
        {
            var query = _dbSet
                .Include(p => p.RoleAdminPermissions)
                .AsQueryable();

            if (filter.PermissionAdminIds != null && filter.PermissionAdminIds.Any())
            {
                query = query.Where(p => filter.PermissionAdminIds.Contains(p.Id));
            }

            if (!String.IsNullOrWhiteSpace(filter.Search))
            {
                string caseInsensitiveSearch = filter.Search.ToLowerInvariant();
                query = query.Where(p => 
                    p.LabelDefault.ToLowerInvariant().Contains(caseInsensitiveSearch) ||
                    p.Code.ToLowerInvariant().Contains(caseInsensitiveSearch)    
                );
            }

            if (filter.RoleAdminId.HasValue)
            {
                query = query.Where(
                    p => p.RoleAdminPermissions
                        .Any(rp => rp.RoleAdminId == filter.RoleAdminId.Value)
                );
            }

            IEnumerable<PermissionAdminDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(permissionDTO => new PermissionAdminInfos()
            {
                Id = permissionDTO.Id,
                Code = permissionDTO.Code,
                Label = permissionDTO.LabelDefault,
                Translations = permissionDTO.Translations?.Select(t => new TranslationPermissionAdmin()
                {
                    LanguageCode = t.LanguageCode,
                    Label = t.Label
                })?.ToList() ?? new List<TranslationPermissionAdmin>()
            }).ToList();
        }
    }
}