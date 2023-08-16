using System;
using Bones.Flow;

namespace Foundation.Template.Shell
{
    public interface IApplicationRequest : IRequest
    {
        Guid ApplicationId { get; }
    }
}