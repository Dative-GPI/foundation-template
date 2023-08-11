using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Foundation.Template.Admin.ViewModels
{
    public class UpsertOrganisationTypePermissionsViewModel
    {
        public Guid OrganisationTypeId { get; set; }
        public List<Guid> PermissionIds { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement> ExtensionData { get; set; }
    }
}