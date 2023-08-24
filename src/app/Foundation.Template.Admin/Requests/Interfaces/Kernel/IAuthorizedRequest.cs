using System.Collections.Generic;
using Bones.Flow;

namespace Foundation.Template.Admin
{
    public interface IAuthorizedRequest : IRequest
    {
        IEnumerable<string> Authorizations { get; }
    }
}