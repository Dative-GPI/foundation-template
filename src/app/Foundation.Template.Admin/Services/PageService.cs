using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using Foundation.Template.Domain.Models;

using Foundation.Template.Admin.Abstractions;
using Foundation.Template.Admin.ViewModels;
using Foundation.Template.Domain.Repositories.Interfaces;
using Bones.Flow;

namespace Foundation.Template.Admin.Services
{
  public class PageService : IPageService
  {
    private IMapper _mapper;
    private IQueryHandler<PagesQuery, IEnumerable<Page>> _pagesQueryHandler;

    public PageService(
            IMapper mapper,
            IQueryHandler<PagesQuery, IEnumerable<Page>> pagesQueryHandler
        )
    {
      _mapper = mapper;
      _pagesQueryHandler = pagesQueryHandler;
    }

    public async Task<IEnumerable<PageViewModel>> GetMany()
    {
      var query = new PagesQuery();

      var pages = await _pagesQueryHandler.HandleAsync(query);

      return _mapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(pages);
    }
  }
}
