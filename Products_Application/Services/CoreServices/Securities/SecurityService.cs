using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Application.Interfaces.CoreServiceInterfaces;
using Products_Application.Interfaces.TokenInterfaces;
using Products_Domain.Models.Users;

namespace Products_Application.Services.CoreServices.Securities
{
    public partial class SecurityService : ISecurityService
    {
        private readonly IJwtToken jwtToken;

        public SecurityService(IJwtToken jwtToken)
        {
            this.jwtToken = jwtToken;
        }

        public string CreateToken(User user)
        {
            ValidateUser(user);
            return jwtToken.GenerateJwtToken(user);
        }
    }
}
