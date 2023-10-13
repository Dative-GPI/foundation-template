using System.Linq;
using AutoMapper;

using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PermissionOrganisationCategory, PermissionOrganisationCategoryViewModel>();
            CreateMap<PermissionOrganisationDetails, PermissionOrganisationDetailsViewModel>();
            CreateMap<PermissionOrganisationInfos, PermissionOrganisationInfosViewModel>();

            CreateMap<PermissionAdminCategory, PermissionAdminCategoryViewModel>();
            CreateMap<PermissionAdminDetails, PermissionAdminDetailsViewModel>();
            CreateMap<PermissionAdminInfos, PermissionAdminInfosViewModel>();

            CreateMap<RouteInfos, RouteInfosViewModel>();

            CreateMap<Translation, TranslationViewModel>();
            CreateMap<ApplicationTranslation, ApplicationTranslationViewModel>();

            CreateMap<RoleAdminDetails, RoleAdminDetailsViewModel>()
                .ForMember(vm => vm.PermissionIds, opt => opt.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));
                
            CreateMap<RoleOrganisationDetails, RoleOrganisationDetailsViewModel>()
                .ForMember(vm => vm.PermissionIds, opt => opt.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));
        }
    }
}