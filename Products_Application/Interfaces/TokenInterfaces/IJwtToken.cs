using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Domain.Models.Users;

namespace Products_Application.Interfaces.TokenInterfaces
{
    public interface IJwtToken
    {
        public string HashToken(string password);

        public string GenerateJwtToken(User user);
    }
}
