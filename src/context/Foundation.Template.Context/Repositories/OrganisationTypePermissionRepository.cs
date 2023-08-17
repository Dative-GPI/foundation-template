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
    public class OrganisationTypePermissionRepository : IOrganisationTypePermissionRepository
    {
        private DbSet<OrganisationTypePermissionDTO> _dbSet;

        public OrganisationTypePermissionRepository(BaseApplicationContext context)
        {
            _dbSet = context.OrganisationTypePermissions;
        }

        public async Task<IEnumerable<OrganisationTypePermissionInfos>> GetMany(OrganisationTypePermissionsFilter filter)
        {
            var query = _dbSet.Include(p => p.Permission).AsQueryable();

            query = query.Where(p => p.OrganisationTypeId == filter.OrganisationTypeId);

            IEnumerable<OrganisationTypePermissionDTO> dtos = await query.AsNoTracking().ToListAsync();

            return dtos.Select(organisationTypePermissionDTO => new OrganisationTypePermissionInfos()
            {
                Id = organisationTypePermissionDTO.Id,
                PermissionId = organisationTypePermissionDTO.PermissionId,
                PermissionCode = organisationTypePermissionDTO.Permission.Code,
                OrganisationTypeId = organisationTypePermissionDTO.OrganisationTypeId,
            });
        }

        public Task RemoveRange(Guid[] permissionsIds)
        {
            _dbSet.RemoveRange(permissionsIds.Select(id => new OrganisationTypePermissionDTO()
            {
                Id = id
            }));

            return Task.CompletedTask;
        }

        public Task CreateRange(IEnumerable<CreateOrganisationTypePermission> payload)
        {
            _dbSet.AddRange(payload.Select(p => new OrganisationTypePermissionDTO()
            {
                Id = Guid.NewGuid(),
                OrganisationTypeId = p.OrganisationTypeId,
                PermissionId = p.PermissionId,
                Disabled = false
            }));

            return Task.CompletedTask;
        }
    }
}