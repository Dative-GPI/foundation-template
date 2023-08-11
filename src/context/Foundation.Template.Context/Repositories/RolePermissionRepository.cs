using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Foundation.Template.Context.DTOs;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Context.Repositories
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private DbSet<RolePermissionDTO> _dbSet;

        public RolePermissionRepository(ApplicationContext context)
        {
            _dbSet = context.RolePermissions;
        }

        public async Task<IEnumerable<RolePermission>> GetMany(RolePermissionsFilter filter)
        {
            var query = _dbSet.Include(p => p.Permission).AsQueryable();
                
            query = query.Where(p => p.RoleId == filter.RoleId);

            IEnumerable<RolePermissionDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(rolePermissionDTO => new RolePermission()
            {
                Id = rolePermissionDTO.Id,
                PermissionId = rolePermissionDTO.PermissionId,
                PermissionCode = rolePermissionDTO.Permission.Code
            });
        }

        public Task RemoveRange(Guid[] permissionsIds)
        {
            _dbSet.RemoveRange(permissionsIds.Select(id => new RolePermissionDTO()
            {
                Id = id
            }));

            return Task.CompletedTask;
        }

        public Task CreateRange(IEnumerable<UpdateRolePermissions> payload)
        {
            _dbSet.AddRange(payload.Select(p => new RolePermissionDTO()
            {
                Id = Guid.NewGuid(),
                RoleId = p.RoleId,
                PermissionId = p.PermissionsId,
                Disabled = false
            }));

            return Task.CompletedTask;
        }

    }
}