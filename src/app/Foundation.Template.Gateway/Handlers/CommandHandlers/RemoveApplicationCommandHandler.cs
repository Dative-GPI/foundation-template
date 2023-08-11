using System;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Foundation.Template.Domain.Repositories.Interfaces;
using Foundation.Template.Gateway.Requests.Commands;

namespace Foundation.Template.Gateway.Handlers
{
    public class RemoveApplicationCommandHandler : IMiddleware<RemoveApplicationCommand>
    {
        private IApplicationRepository _applicationRepository;

        public RemoveApplicationCommandHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task HandleAsync(RemoveApplicationCommand request, Func<Task> next, CancellationToken cancellationToken)
        {
            await _applicationRepository.Remove(request.ApplicationId);
        }
    }
}