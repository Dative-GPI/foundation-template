using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Bones.Domain;
using Bones.Repository.Interfaces;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Interfaces;

using Foundation.Template.Context.DTOs;

namespace Foundation.Template.Context.Repositories
{
    public class RoleAdminRepository : IRoleAdminRepository
    {
        private DbSet<RoleAdminPermissionDTO> _dbSet;

        public RoleAdminRepository(ApplicationContext context)
        {
            _dbSet = context.RoleAdminPermissions;
        }

        public async Task<RoleAdminDetails> Get(Guid id)
        {
            var permissions = await _dbSet
                .Include(p => p.PermissionAdmin)
                .Where(p => p.RoleAdminId == id)
                .AsNoTracking()
                .ToListAsync();

            return new RoleAdminDetails()
            {
                Id = id,
                Permissions = permissions.Select(p => new PermissionItem()
                {
                    Id = p.PermissionAdminId,
                    Code = p.PermissionAdmin.Code
                }).ToList()
            };
        }

        public async Task<IEntity<Guid>> Update(UpdateRoleAdmin payload)
        {
            var formerPermissions = await _dbSet.Where(p => p.RoleAdminId == payload.Id).ToListAsync();

            _dbSet.RemoveRange(formerPermissions);

            _dbSet.AddRange(payload.PermissionIds.Select(p => new RoleAdminPermissionDTO()
            {
                Id = Guid.NewGuid(),
                RoleAdminId = payload.Id,
                PermissionAdminId = p
            }));

            return new FakeEntity<Guid>(payload.Id);
        }
    }
}