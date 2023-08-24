using System;
using Bones.Flow;

namespace Foundation.Template.Admin
{
    public interface IActorRequest : IRequest
    {
        Guid ActorId { get; }
    }
}