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
    public class RoleAdminPermissionRepository : IRoleAdminPermissionRepository
    {
        private DbSet<RoleAdminPermissionDTO> _dbSet;

        public RoleAdminPermissionRepository(ApplicationContext context)
        {
            _dbSet = context.RoleAdminPermissions;
        }

        public async Task<IEnumerable<RoleAdminPermission>> GetMany(RoleAdminPermissionsFilter filter)
        {
            var query = _dbSet.Include(p => p.PermissionAdmin).AsQueryable();
                
            query = query.Where(p => p.RoleAdminId == filter.RoleAdminId);

            IEnumerable<RoleAdminPermissionDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(rolePermissionDTO => new RoleAdminPermission()
            {
                Id = rolePermissionDTO.Id,
                PermissionAdminId = rolePermissionDTO.PermissionAdminId,
                PermissionAdminCode = rolePermissionDTO.PermissionAdmin.Code
            }).ToList();
        }

        public Task RemoveRange(Guid[] permissionsIds)
        {
            _dbSet.RemoveRange(permissionsIds.Select(id => new RoleAdminPermissionDTO()
            {
                Id = id
            }));

            return Task.CompletedTask;
        }

        public Task CreateRange(IEnumerable<UpdateRoleAdminPermissions> payload)
        {
            _dbSet.AddRange(payload.Select(p => new RoleAdminPermissionDTO()
            {
                Id = Guid.NewGuid(),
                RoleAdminId = p.RoleAdminId,
                PermissionAdminId = p.PermissionAdminId,
                Disabled = false
            }));

            return Task.CompletedTask;
        }

    }
}