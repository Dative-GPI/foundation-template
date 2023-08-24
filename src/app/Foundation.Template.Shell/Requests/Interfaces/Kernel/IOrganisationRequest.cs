using System;
using Bones.Flow;

namespace Foundation.Template.Shell
{
    public interface IOrganisationRequest : IRequest
    {
        Guid OrganisationId { get; }
    }
}