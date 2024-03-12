using System;
using System.Linq;
using System.Threading.Tasks;
using Foundation.Template.Core.Abstractions;
using Foundation.Template.Domain.Models;
using Foundation.Template.Domain.Repositories.Filters;
using Foundation.Template.Domain.Repositories.Interfaces;

namespace Foundation.Template.Core.Providers
{
    public class OrganisationTypeTableProvider : IOrganisationTypeTableProvider
    {
        private IRequestContextProvider _requestContextProvider;
        private ITableRepository _tableRepository;
        private IOrganisationTypeDispositionRepository _organisationTypeDispositionRepository;

        public OrganisationTypeTableProvider(IRequestContextProvider requestContextProvider,
            ITableRepository tableRepository,
            IOrganisationTypeDispositionRepository organisationTypeDispositionRepository)
        {
            _requestContextProvider = requestContextProvider;
            _tableRepository = tableRepository;
            _organisationTypeDispositionRepository = organisationTypeDispositionRepository;
        }

        public async Task<OrganisationTypeTableDetails> Get(Guid organisationTypeId, Guid tableId)
        {
            var dispositions = await _organisationTypeDispositionRepository.GetMany(new ColumnOrganisationTypesFilter()
            {
                OrganisationTypeId = organisationTypeId,
                TableId = tableId
            });

            return new OrganisationTypeTableDetails()
            {
                OrganisationTypeId = organisationTypeId,
                TableId = tableId,
                Dispositions = dispositions.ToList()
            };
        }
    }
}