using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Permissions
{
    public class UpdatePermissionDTO
    {
        [JsonPropertyName("permission_id")]
        public Guid PermissionId { get; set; }

        [Required(ErrorMessage = "Permission name is required")]
        [JsonPropertyName("permission_name")]
        public string PermissionName { get; set; }
    }
}
