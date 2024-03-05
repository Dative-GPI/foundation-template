using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Core.ViewModels;

namespace Foundation.Template.Core.Abstractions
{
    public interface IUserOrganisationDispositionService
    {
        Task<UserOrganisationDispositionViewModel> GetMany(string tableCode);
        Task Update(string tableCode, UpdateUserOrganisationDispositionViewModel payload);
    }
}