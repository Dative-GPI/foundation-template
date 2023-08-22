using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Context.Abstractions;

using static Foundation.Template.Fixtures.BaseFixtureManager;

namespace Foundation.Template.Fixtures
{
    public static class PermissionProvider
    {
        private const BindingFlags PublicStaticFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;

        public static FixtureGenerator<ICodeEntity> GetPermissions(Type type)
        {
            var permissions = GetAllPermissions(type);
            return () => Task.FromResult<List<ICodeEntity>>(permissions.Cast<ICodeEntity>().ToList());
        }

        public static FixtureGenerator<ICodeEntity> GetCategories(Type type)
        {
            var permissions = GetAllPermissions(type);
            var categories = ExtractCategories(permissions);

            return () => Task.FromResult<List<ICodeEntity>>(categories);
        }

        private static List<ICodeEntity> ExtractCategories(List<Fixture> permissions)
        {
            return permissions
                .Select(p => new { Code = String.Join('.', p.Code.Split(".")[0..^1]), Value = p.Value })
                .GroupBy(p => p.Code)
                .Select(kv => new Fixture()
                {
                    Code = kv.Key,
                    Value = kv.SelectMany(p => p.Value.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries))
                        .GroupBy(word => word)
                        .OrderByDescending(g => g.Count() + g.Key.Length)
                        .FirstOrDefault()?.Key
                })
                .ToList<ICodeEntity>();
        }

        private static List<Fixture> GetAllPermissions(Type type)
        {
            return type.GetFields(PublicStaticFlags)
                .Where(field => field.IsLiteral && !field.IsInitOnly)
                .Select(
                    field => new Fixture()
                    {
                        Code = field.Name,
                        Value = field.GetRawConstantValue()?.ToString()
                    }
                ).ToList();
        }
    }
}