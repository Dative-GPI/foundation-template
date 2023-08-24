using System;
using Bones.Flow;

namespace Foundation.Template.Shell
{
    public interface IActorRequest : IRequest
    {
        Guid ActorId { get; }
    }
}