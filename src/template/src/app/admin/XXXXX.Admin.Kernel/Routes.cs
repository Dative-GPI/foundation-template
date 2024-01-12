using System.Collections.Generic;
using XXXXX.Admin.Kernel.Models;

namespace XXXXX.Admin.Kernel
{
    public static class Routes
    {
        private static readonly RouteDefinition[] ROUTES = new RouteDefinition[] {
            new RouteDefinition()
            {
                Authorizations = new string[] {},
                Path = "/admin/XXXXX/examples",
                Name = "apps.example",
                DrawerCategoryLabelDefault = "XXXXX",
                DrawerCategoryCode = "drawer.examples.category",
                DrawerIcon = "supervised_user_circle",
                DrawerLabelDefault = "Example",
                DrawerLabelCode = "drawer.examples.title",
                Exact = true,
                ShowOnDrawer = true
            },
            new RouteDefinition()
            {
                Authorizations = new string[] {},
                Path = "/admin/XXXXX/examples/drawer",
                Name = "apps.example.drawer",
                DrawerCategoryLabelDefault = null,
                DrawerCategoryCode = null,
                DrawerIcon = null,
                DrawerLabelDefault = null,
                DrawerLabelCode = null,
                Exact = false,
                ShowOnDrawer = false
            },
        };


        public static IEnumerable<RouteDefinition> GetRoutes()
        {
            return ROUTES;
        }
    }
}