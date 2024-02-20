using System.Collections.Generic;
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
            CreateMap<PermissionOrganisationTypeInfos, PermissionOrganisationTypeInfosViewModel>()
                .ForMember(p => p.PermissionLabel, opt => opt.MapFromTranslation(t => t.TranslationPermissions, t => t.Label));

            CreateMap<PermissionApplicationCategory, PermissionApplicationCategoryViewModel>();
            CreateMap<PermissionApplicationDetails, PermissionApplicationDetailsViewModel>();
            CreateMap<PermissionApplicationInfos, PermissionApplicationInfosViewModel>();

            CreateMap<RouteInfos, RouteInfosViewModel>();

            CreateMap<Translation, TranslationViewModel>();
            CreateMap<ApplicationTranslation, ApplicationTranslationViewModel>();

            CreateMap<RoleApplicationDetails, RoleApplicationDetailsViewModel>()
                .ForMember(vm => vm.PermissionIds, opt => opt.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));

            CreateMap<RolePermissionOrganisationDetails, RolePermissionOrganisationDetailsViewModel>()
                .ForMember(vm => vm.PermissionIds, opt => opt.MapFrom(r => r.Permissions.Select(p => p.Id).ToList()));

        }
    }
}