using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Application.DTOs.Users
{
    public class ReadUserDTO
    {
        [JsonPropertyName("user_id")]
        public Guid UsersId { get; set; }

        public string Username { get; set; }    
    }
}
