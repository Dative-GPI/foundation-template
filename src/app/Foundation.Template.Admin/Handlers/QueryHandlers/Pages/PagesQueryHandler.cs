using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Bones.Flow;

using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Admin.Handlers
{
    public class PagesQueryHandler : IMiddleware<PagesQuery, IEnumerable<Page>>
    {
        private IPageRepository _pageRepository;

        public PagesQueryHandler(
            IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public Task<IEnumerable<Page>> HandleAsync(PagesQuery request, Func<Task<IEnumerable<Page>>> next, CancellationToken cancellationToken)
        {
            var Pages = _pageRepository.GetMany();

            return Pages;
        }
    }
}