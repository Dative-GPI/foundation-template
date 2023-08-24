using System;
using Bones.Flow;

namespace Foundation.Template.Core
{
    public interface IOrganisationRequest : IRequest
    {
        Guid OrganisationId { get; }
    }
}