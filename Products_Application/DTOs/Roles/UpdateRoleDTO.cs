using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Roles
{
    public class UpdateRoleDTO
    {
        [JsonPropertyName("role_id")]
        public Guid RoleId { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        public string Name { get; set; }
    }
}
