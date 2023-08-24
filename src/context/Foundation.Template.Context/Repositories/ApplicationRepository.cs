using System;
using System.Threading.Tasks;
using Bones.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Foundation.Template.Context.DTOs;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Context.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private DbSet<ApplicationDTO> _dbSet;

        public ApplicationRepository(
            BaseApplicationContext context
        )
        {
            _dbSet = context.Applications;
        }

        public Task<IEntity<Guid>> Create(CreateApplication payload)
        {
            var dto = new ApplicationDTO()
            {
                Id = payload.ApplicationId,
                Host = payload.Host,
                AdminJWT = payload.AdminJWT,
                Disabled = false
            };

            _dbSet.Add(dto);

            return Task.FromResult<IEntity<Guid>>(dto);
        }

        public async Task<ApplicationDetails> Get(Guid applicationId)
        {
            var applicationDTO = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == applicationId);

            if (applicationDTO == default)
            {
                return null;
            }

            return new ApplicationDetails()
            {
                Id = applicationDTO.Id,
                Host = applicationDTO.Host,
                AdminJWT = applicationDTO.AdminJWT,
                Disabled = applicationDTO.Disabled
            };
        }

        public async Task<IEntity<Guid>> Update(UpdateApplication payload)
        {
            var dto = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == payload.ApplicationId);

            if (dto == default)
            {
                return null;
            }
            
            dto.AdminJWT = payload.AdminJWT;
            dto.Host = payload.Host;
            dto.Disabled = false;

            _dbSet.Update(dto);

            return dto;
        }

        public async Task Remove(Guid applicationId)
        {
            var applicationDTO = await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == applicationId);

            applicationDTO.Disabled = true;

            _dbSet.Update(applicationDTO);
        }
    }
}