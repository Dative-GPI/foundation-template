using AutoMapper;
using AutoMapper.Internal;

using Foundation.Template.Domain.Models;
using Foundation.Template.Core.ViewModels;

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
            CreateMap<RoleOrganisationDetails, RoleOrganisationDetailsViewModel>();
            CreateMap<ActionInfos, ActionInfosViewModel>();
        }
    }
}