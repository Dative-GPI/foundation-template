

using System;
using Bones.Flow;
using Bones.Repository.Interfaces;

namespace Foundation.Template.Gateway.Requests.Commands
{
    public class CreateApplicationCommand : IRequest<IEntity<Guid>>
    {
        public Guid ApplicationId { get; set; }
        public string AdminHost { get; set; }
        public string CoreHost { get; set; }
        public string AdminJWT { get; set; }
    }
}