using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Domain.Models.Tokens
{
    public class UserToken
    {
        public Guid UserID { get; set; }
        public string Token { get; set; }
    }
}
