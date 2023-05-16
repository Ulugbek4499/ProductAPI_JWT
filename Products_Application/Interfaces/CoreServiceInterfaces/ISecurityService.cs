using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Domain.Models.Users;

namespace Products_Application.Interfaces.CoreServiceInterfaces
{
    public interface ISecurityService
    {
        string CreateToken(User user);
    }
}
