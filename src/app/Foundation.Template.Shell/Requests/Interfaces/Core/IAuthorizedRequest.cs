using System.Collections.Generic;
using Bones.Flow;

namespace Foundation.Template.Shell
{
    public interface IAuthorizedRequest : IRequest
    {
        IEnumerable<string> Authorizations { get; }
    }
}