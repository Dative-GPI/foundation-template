using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Interfaces
{
    public interface IApplicationTranslationService
    {
        Task<IEnumerable<ApplicationTranslationViewModel>> GetMany();
        Task UpdateRange(IEnumerable<UpdateApplicationTranslationViewModel> payload);
    }
}