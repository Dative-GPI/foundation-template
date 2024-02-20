using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using Foundation.Template.Context.Abstractions;

namespace Foundation.Template.Fixtures
{
    public static class EntityPropertyHelper
    {
        const string ENTITY_PATTERN = "InfosViewModel";

        // static List<Assembly> Assemblies = new List<Assembly>() {
        //     Foundation.Core.Kernel.KernelAssembly.Get(),
        //     Foundation.Admin.Kernel.KernelAssembly.Get()
        // };

        // static List<string> Namespaces = new List<string>() {
        //     "Foundation.Core.Kernel.ViewModels",
        //     "Foundation.Template.Admin.ViewModels"
        // };

        public static List<EntityProperty> GetAll(List<Assembly> assemblies, List<string> namespaces)
        {
            var result = assemblies.SelectMany(a => a.GetTypes())
                .Where(t => namespaces.Any(n => t.Namespace?.StartsWith(n) ?? false))
                .Where(t => t.Name.EndsWith(ENTITY_PATTERN))
                .SelectMany(t =>
                    t.GetProperties().Select(p => new EntityProperty()
                    {
                        Code = $"{t.FullName}.{p.Name}",
                        Value = p.Name.ToCamelCase(),
                        EntityType = t.FullName,
                        LabelDefault = p.Name
                    })
                ).ToList();

            return result;
        }
    }
}