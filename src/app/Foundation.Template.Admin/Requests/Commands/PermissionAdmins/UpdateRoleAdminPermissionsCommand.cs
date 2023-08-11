using System;
using System.Collections.Generic;
using System.Text.Json;
using Bones.Flow;
using Bones.Repository.Interfaces;
using static Foundation.Template.Admin.Authorizations;

namespace Foundation.Template.Admin
{
    public class UpdateRoleAdminCommand : ICoreRequest, IRequest<IEntity<Guid>>
    {
        public IEnumerable<string> Authorizations => new string[] {};
		public Guid ApplicationId { get; set; }
        public Guid ActorId { get; set; }

        public Guid RoleAdminId { get; set; }
        public List<Guid> PermissionIds { get; set; }
        public Dictionary<string, JsonElement> ExtensionData { get; set; }
    }
}