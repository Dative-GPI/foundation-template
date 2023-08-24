using System;
using Bones.Flow;

namespace Foundation.Template.Admin
{
    public interface IApplicationRequest : IRequest
    {
        Guid ApplicationId { get; }
    }
}