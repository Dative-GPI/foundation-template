using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Context.Abstractions;
using Foundation.Template.Fixtures;
using System.Linq;
using System.Reflection;

using Foundation.Clients.Fixtures.Services;

namespace XXXXX.Context.Migrations
{
    public static class EntityPropertyProvider
    {
        static List<Assembly> Assemblies = new List<Assembly>() {
            XXXXX.Template.Core.Kernel.KernelAssembly.Get(),
            XXXXX.Template.Admin.Kernel.KernelAssembly.Get()
        };

        static List<string> Namespaces = new List<string>() {
            "XXXXX.Template.Core.Kernel.ViewModels",
            "XXXXX.Template.Admin.Kernel.ViewModels"
        };

        public static Task<List<EntityProperty>> GetAllEntityProperties()
        {
            var entityProperties = EntityPropertyHelper.GetAll(Assemblies, Namespaces);

            var result = entityProperties.DistinctBy(t => t.Code).ToList();

            return Task.FromResult(result);
        }
    }
}
