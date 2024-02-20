using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Foundation.Template.Admin.ViewModels;

namespace Foundation.Template.Admin.Abstractions
{
    public interface IEntityPropertyService
    {
        Task<IEnumerable<EntityPropertyViewModel>> GetMany(EntityPropertiesFilterViewModel filter);
    }
}