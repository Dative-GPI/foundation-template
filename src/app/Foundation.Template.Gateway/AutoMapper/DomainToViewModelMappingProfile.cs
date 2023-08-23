using AutoMapper;

using Foundation.Template.Gateway.ViewModels;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Gateway.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ApplicationTranslation, ApplicationTranslationViewModel>();
            CreateMap<ApplicationDetails, ApplicationDetailsViewModel>();
        }
    }
}