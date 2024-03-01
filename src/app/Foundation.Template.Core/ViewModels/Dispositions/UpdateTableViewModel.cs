using System;
using System.Collections.Generic;

namespace Foundation.Template.Core.ViewModels
{
    public class UpdateTableViewModel
    {
        public IEnumerable<UpdateColumnViewModel> Columns { get; set; }
    }
}