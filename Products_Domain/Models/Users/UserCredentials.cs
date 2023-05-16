using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Products_Domain.Models.Users
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
