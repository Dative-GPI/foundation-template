using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Microsoft.EntityFrameworkCore;

using Foundation.Template.Fixtures.Abstractions;

namespace Foundation.Template.Fixtures
{
    public class FixtureHelper : IFixtureHelper
    {
        const string FIXTURES_DIRECTORY = "Fixtures";
        static readonly string BASE_DIRECTORY = Directory.GetCurrentDirectory();

        public void Feed<TEntity>(ModelBuilder builder) where TEntity : class
        {
            builder.Entity<TEntity>()
                .HasData(Get<TEntity>().Result);
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity>()
        {
            var file = GetPath<TEntity>();
            var data = await ReadAll<TEntity>(file);
            return data;
        }

        public async Task Save<TEntity>(IEnumerable<TEntity> entities)
        {
            var file = GetPath<TEntity>();
            await WriteAll<TEntity>(file, entities);
        }

        private async Task<IEnumerable<TEntity>> ReadAll<TEntity>(string file)
        {
            if (!File.Exists(file))
            {
                throw new Exception($"Unable to find file {file}");
            }

            IEnumerable<TEntity> result;

            switch (Path.GetExtension(file))
            {
                case ".json":
                    result = JsonSerializer.Deserialize<List<TEntity>>(
                        await File.ReadAllTextAsync(file)
                    );
                    break;
                case ".xml":
                    result = ReadXML<TEntity>(file);
                    break;
                default:
                    throw new Exception($"Unsupported file type {Path.GetExtension(file)}");
            }

            return result;
        }

        private async Task WriteAll<TEntity>(string file, IEnumerable<TEntity> entities)
        {
            switch (Path.GetExtension(file))
            {
                case ".json":
                    await File.WriteAllTextAsync(
                        file,
                        JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true })
                    );
                    break;
                case ".xml":
                    WriteXML<TEntity>(file, entities);
                    break;
                default:
                    throw new Exception($"Unsupported file type {Path.GetExtension(file)}");
            }
        }

        private void WriteXML<TEntity>(string file, IEnumerable<TEntity> entities)
        {
            var serializer = GetSerializer<TEntity>();

            using var stream = File.OpenWrite(file);
            serializer.Serialize(stream, entities);
        }

        private IEnumerable<TEntity> ReadXML<TEntity>(string file)
        {
            var serializer = GetSerializer<TEntity>();

            using var stream = File.OpenRead(file);
            return (List<TEntity>)serializer.Deserialize(stream);
        }

        private XmlSerializer GetSerializer<TEntity>()
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();

            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (
                    property.PropertyType.IsPrimitive ||
                    property.PropertyType == typeof(Decimal) ||
                    property.PropertyType == typeof(String) ||
                    property.PropertyType == typeof(Guid)
                )
                {
                    overrides.Add(typeof(TEntity), property.Name, new XmlAttributes { XmlAttribute = new XmlAttributeAttribute() });
                }
                // else
                // {
                //     overrides.Add(typeof(TEntity), property.Name, new XmlAttributes { XmlIgnore = true });
                // }
            }

            return new XmlSerializer(typeof(List<TEntity>), overrides);
        }

        private string GetPath<TEntity>()
        {
            var baseName = GetFileBaseName<TEntity>();
            var files = Directory.EnumerateFiles(Path.Join(BASE_DIRECTORY, FIXTURES_DIRECTORY), $"*{baseName}*");

            if (files.Count() > 1)
            {
                throw new Exception($"Multiple files found for {baseName}");
            }

            if (files.Any())
            {
                return files.First();
            }

            return $"{baseName}.xml";
        }

        private string GetFileBaseName<TEntity>()
        {
            return PascalToKebabCase(typeof(TEntity).Name);
        }

        private string PascalToKebabCase(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return Regex.Replace(
                value,
                "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z0-9])",
                "-$1",
                RegexOptions.Compiled)
                .Trim()
                .ToLower();
        }
    }
}
