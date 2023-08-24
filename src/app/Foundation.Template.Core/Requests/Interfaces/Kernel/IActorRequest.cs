using System;
using Bones.Flow;

namespace Foundation.Template.Core
{
    public interface IActorRequest : IRequest
    {
        Guid ActorId { get; }
    }
}