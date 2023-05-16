using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Domain.Models.Tokens
{
    public class TokenConfiguration
    {
        public string Key { get; set; }
        public string Issue { get; set; }
        public string Audience { get; set; }
    }
}
