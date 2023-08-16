using AutoMapper;
using AutoMapper.Internal;

using Foundation.Template.Domain.Models;
using Foundation.Template.Shell.ViewModels;

namespace Foundation.Template.Shell.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            InternalApi.Internal(this).ForAllMaps(TranslationMapper.Map);

            CreateMap<RouteInfos, RouteInfosViewModel>();

            CreateMap<PermissionInfos, PermissionInfosViewModel>();
            CreateMap<PermissionCategory, PermissionCategoryViewModel>();
            CreateMap<RoleOrganisationDetails, RoleOrganisationDetailsViewModel>();
        }
    }
}