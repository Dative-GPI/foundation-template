using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bones.Repository.Interfaces;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Commands;
using Foundation.Template.Domain.Repositories.Filters;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IRolePermissionOrganisationRepository
    {
        Task<RolePermissionOrganisationDetails> Get(Guid id);
        Task<IEntity<Guid>> Update(UpdateRolePermissionOrganisation payload);
    }
}