using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Users
{
    public class CreateUserDTO
    {

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Password is invalid")]
        [Compare("ConfirmPassword", ErrorMessage = "Password do not match")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
