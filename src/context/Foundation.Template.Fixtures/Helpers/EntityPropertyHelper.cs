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
                    t.BaseType.GetProperties().Select(p => new EntityProperty()
                    {
                        Code = $"{t.FullName}.{p.Name}",
                        Value = p.Name.ToCamelCase(),
                        EntityType = t.FullName,
                        LabelDefault = p.Name,
                        ParentCode = ConvertFoundationModelToViewModel($"{t.BaseType.FullName}.{p.Name}")
                    }).Concat(t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(p => new EntityProperty()
                    {
                        Code = $"{t.FullName}.{p.Name}",
                        Value = p.Name.ToCamelCase(),
                        EntityType = t.FullName,
                        LabelDefault = p.Name,
                    })
                )).ToList();

            return result;
        }

        private static string ConvertFoundationModelToViewModel(string foundationModel)
        {
            var result = foundationModel.Replace("FoundationModel", "ViewModel");
            result = result.Replace("Clients.Core", "Core.Kernel");
            result = result.Replace("Clients.Admin", "Admin.Kernel");

            return result;
        }
    }
}