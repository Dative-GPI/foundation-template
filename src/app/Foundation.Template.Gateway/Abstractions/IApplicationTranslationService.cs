using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Gateway.ViewModels;

namespace Foundation.Template.Gateway.Abstractions
{
    public interface IApplicationTranslationService
    {
        Task<IEnumerable<ApplicationTranslationViewModel>> GetMany();
    }
}