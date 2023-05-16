using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Permissions
{
    public class DeletePermissionDTO
    {
        [JsonPropertyName("permission_id")]
        public Guid PermissionId { get; set; }
    }
}
