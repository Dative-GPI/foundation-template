using System;
using System.Collections.Generic;

namespace XXXXX.Admin.Kernel.Models
{
    public class RouteDefinition
    {
        public IEnumerable<string> Authorizations { get; set; }

        public bool ShowOnDrawer { get; set; }

        public string DrawerIcon { get; set; }
        public string DrawerCategoryLabelDefault { get; set; }
        public string DrawerCategoryCode { get; set; }

        public string DrawerLabelDefault { get; set; }
        public string DrawerLabelCode { get; set; }

        public string Path { get; set; }
        public string Name { get; set; }

        public bool Exact { get; set; }

    }
}
