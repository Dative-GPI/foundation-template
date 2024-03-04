using System;
using System.Collections;
using System.Collections.Generic;

namespace Foundation.Template.Admin.ViewModels
{
    public class EntityPropertyTranslationsFilterViewModel
    {
        public Guid? EntityPropertyId { get; set; }

        public IEnumerable<Guid> EntityPropertyIds { get; set; }
    }
}