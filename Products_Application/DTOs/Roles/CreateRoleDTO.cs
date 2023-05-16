using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Roles
{
    public class CreateRoleDTO
    {
        [Required(ErrorMessage = "Role name is required")]
        public string Name { get; set; }
    }
}
