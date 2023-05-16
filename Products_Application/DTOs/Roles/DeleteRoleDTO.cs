using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Roles
{
    public class DeleteRoleDTO
    {
        [JsonPropertyName("role_id")]
        public Guid RoleId { get; set; }
    }
}
