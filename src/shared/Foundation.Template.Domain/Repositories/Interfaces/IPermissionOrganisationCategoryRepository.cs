using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Domain.Models;

namespace Foundation.Template.Domain.Repositories.Interfaces
{
    public interface IPermissionOrganisationCategoryRepository
    {
        Task<IEnumerable<PermissionCategory>> GetMany();
    }
}