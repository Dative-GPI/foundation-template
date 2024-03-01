using AutoMapper;
using AutoMapper.Internal;

using Foundation.Template.Domain.Models;
using Foundation.Template.Core.ViewModels;
using System.Linq;

namespace Foundation.Template.Core.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            InternalApi.Internal(this).ForAllMaps(TranslationMapper.Map);

            CreateMap<RouteInfos, RouteInfosViewModel>();

            CreateMap<PermissionOrganisationInfos, PermissionOrganisationInfosViewModel>();
            CreateMap<PermissionOrganisationCategory, PermissionOrganisationCategoryViewModel>();
            CreateMap<RolePermissionOrganisationDetails, RolePermissionOrganisationDetailsViewModel>()
                .ForMember(vm => vm.PermissionIds, opt => opt.MapFrom(p => p.Permissions.Select(p => p.Id).ToList()));
            CreateMap<ActionInfos, ActionInfosViewModel>();

            CreateMap<UserOrganisationColumn, UserOrganisationColumnInfosViewModel>();
            CreateMap<UserOrganisationTable, UserOrganisationTableDetailsViewModel>();
            CreateMap<UserOrganisationTable, UserOrganisationTableInfosViewModel>();


        }
    }
}