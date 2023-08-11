

using System;
using Bones.Flow;

namespace Foundation.Template.Gateway.Requests.Commands
{
    public class RemoveApplicationCommand : IRequest
    {
        public Guid ApplicationId { get; set; }
    }
}