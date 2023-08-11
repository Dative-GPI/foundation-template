using AutoMapper;

using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PermissionCategory, PermissionCategoryViewModel>();
            CreateMap<PermissionDetails, PermissionDetailsViewModel>();
            CreateMap<PermissionInfos, PermissionInfosViewModel>();

            CreateMap<PermissionAdminCategory, PermissionAdminCategoryViewModel>();
            CreateMap<PermissionAdminDetails, PermissionAdminDetailsViewModel>();
            CreateMap<PermissionAdminInfos, PermissionAdminInfosViewModel>();

            CreateMap<RouteInfos, RouteInfosViewModel>();

            CreateMap<Translation, TranslationViewModel>();
            CreateMap<ApplicationTranslation, ApplicationTranslationViewModel>();
        }
    }
}