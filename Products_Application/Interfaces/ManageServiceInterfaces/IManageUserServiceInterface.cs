using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Domain.Models.Tokens;
using Products_Domain.Models.Users;

namespace Products_Application.Interfaces.ManageServiceInterfaces
{
    public interface IManageUserServiceInterface
    {
        UserToken CreateUserToken(User user);
    }
}
