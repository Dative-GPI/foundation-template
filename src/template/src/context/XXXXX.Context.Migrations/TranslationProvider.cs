using System.Threading.Tasks;
using System.Collections.Generic;

using Foundation.Template.Context.Abstractions;
using Foundation.Template.Fixtures;
using System.Linq;

namespace XXXXX.Context.Migrations
{
    public static class TranslationProvider
    {
        static readonly List<string> PROJECTS = new List<string>()
        {
            "../../../src/app/admin/XXXXX.Admin.UI",
            "../../../src/app/core/XXXXX.Core.UI",
        };

        public static async Task<List<Fixture>> GetAllTranslations()
        {
            var translations = new List<Fixture>();

            foreach (var project in PROJECTS)
            {
                var translation = await TranslationHelper.GetTranslations(project);
                translations.AddRange(translation);
            }

            return translations.DistinctBy(t => t.Code).ToList();
        }
    }
}
