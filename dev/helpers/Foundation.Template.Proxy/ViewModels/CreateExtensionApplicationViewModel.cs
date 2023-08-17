using System;
using System.Collections.Generic;

namespace Foundation.Template.Proxy.ViewModels
{
    public class CreateExtensionApplicationViewModel
    {
        public Guid? ExtensionId { get; set; }
        public List<Guid> PermissionIds { get; set; }
    }
}