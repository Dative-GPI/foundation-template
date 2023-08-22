using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using Foundation.Template.Context.Abstractions;

using Foundation.Template.Fixtures.Abstractions;

namespace Foundation.Template.Fixtures
{
    public class BaseFixtureManager
    {
        public delegate Task<List<T>> FixtureGenerator<T>();
        private List<Func<Task>> _saveActions = new List<Func<Task>>();

        protected ILogger<BaseFixtureManager> Logger { get; private set; }
        protected IFixtureHelper FixtureHelper { get; private set; }

        public BaseFixtureManager(
            ILogger<BaseFixtureManager> logger,
            IFixtureHelper fixtureHelper)
        {
            Logger = logger;
            FixtureHelper = fixtureHelper;
        }

        public async Task Run()
        {
            Logger.LogInformation("Start");

            foreach (var action in _saveActions)
            {
                await action();
            }
        }

        public void Add<TDTO, TPartial>(
            FixtureGenerator<TPartial> provider,
            Func<TPartial, TDTO> create,
            Func<TPartial, TDTO, TDTO> update = default)
            where TDTO : ICodeEntity
            where TPartial : ICodeEntity
        {
            if(update == default)
            {
                update = (partial, former) => former;
            }

            _saveActions.Add(() => Save<TDTO, TPartial>(provider, create, update));
        }

        private async Task Save<TDTO, TPartial>(
            FixtureGenerator<TPartial> provider,
            Func<TPartial, TDTO> create,
            Func<TPartial, TDTO, TDTO> update)
            where TDTO : ICodeEntity
            where TPartial : ICodeEntity
        {
            var formers = await FixtureHelper.Get<TDTO>();

            Logger.LogInformation("Found {count} {type} existing", formers.Count(), typeof(TDTO).Name);

            var alls = await provider();

            Logger.LogInformation("Found {count} {type} actual", alls.Count(), typeof(TDTO).Name);

            var news = alls.ExceptBy(formers.Select(f => f.Code), a => a.Code).ToList();

            Logger.LogInformation("{count} {type} new", news.Count(), typeof(TDTO).Name);

            var saved = formers.Join(alls, f => f.Code, a => a.Code, (f, a) => update(a, f)) // formers still present
                .Concat(news.Select(n => create(n))) // + news
                .ToList();

            await FixtureHelper.Save<TDTO>(saved);

            Logger.LogInformation("{count} {type} saved", saved.Count(), typeof(TDTO).Name);
        }
    }
}