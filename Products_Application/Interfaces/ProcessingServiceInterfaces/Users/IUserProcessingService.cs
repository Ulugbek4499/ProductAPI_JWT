using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Domain.Models.Users;

namespace Products_Application.Interfaces.ProcessingServiceInterfaces.Users
{
    public interface IPermissionProcessingService
    {
        User GetUserByUserCredentials(UserCredentials userCredentials);
        User GetUserByUserName(string userName);
    }
}
