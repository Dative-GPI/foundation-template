using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;
using Bones.Flow;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Domain.Models;

namespace Foundation.Template.Admin.Services
{
    public class EntityPropertyService : IEntityPropertyService
    {
        private readonly IQueryHandler<EntityPropertiesQuery, IEnumerable<EntityProperty>> _entityPropertiesQueryHandler;
        private readonly IMapper _mapper;

        public EntityPropertyService(
            IQueryHandler<EntityPropertiesQuery, IEnumerable<EntityProperty>> entityPropertiesQueryHandler,
            IMapper mapper
        )
        {
            _entityPropertiesQueryHandler = entityPropertiesQueryHandler;
            _mapper = mapper;
        }


        public async Task<IEnumerable<EntityPropertyViewModel>> GetMany(EntityPropertiesFilterViewModel filter)
        {
            var query = new EntityPropertiesQuery()
            {

            };

            var result = await _entityPropertiesQueryHandler.HandleAsync(query);

            return _mapper.Map<IEnumerable<EntityProperty>, IEnumerable<EntityPropertyViewModel>>(result);
        }
    }
}