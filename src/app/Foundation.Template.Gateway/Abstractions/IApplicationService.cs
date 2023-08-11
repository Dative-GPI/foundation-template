using System;
using System.Threading.Tasks;
using Foundation.Template.Gateway.ViewModels;

namespace Foundation.Template.Gateway.Abstractions
{
    public interface IApplicationService
    {
        Task<ApplicationDetailsViewModel> Create(CreateApplicationViewModel payload);
        Task Remove(Guid applicationId);
    }
}