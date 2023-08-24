using System.Collections.Generic;

using AutoMapper;

namespace Foundation.Template.Core.AutoMapper
{
    public class AutoMapperConfig
    {
        public static List<Profile> Profiles = new List<Profile>()
        {
            new DomainToViewModelMappingProfile()
        };
    }
}