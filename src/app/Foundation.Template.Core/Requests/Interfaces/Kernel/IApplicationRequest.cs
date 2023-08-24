using System;
using Bones.Flow;

namespace Foundation.Template.Core
{
    public interface IApplicationRequest : IRequest
    {
        Guid ApplicationId { get; }
    }
}