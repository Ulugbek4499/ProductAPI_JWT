using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products_Domain.Models.Tokens
{
    public class Token
    { 
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
