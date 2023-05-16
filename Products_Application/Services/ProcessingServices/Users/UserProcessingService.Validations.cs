using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Application.Services.ProcessingServices.Users.Exceptions;

namespace Products_Application.Services.ProcessingServices.Users
{
    public partial class UserProcessingService
    {
        private static void ValidateUsernameAndPassword(string username, string password)
        {
            if (username == null || password == null)
            {
                throw new InvalidUserProcessingException();
            }
        }

        private void ValidateUsername(string userName)
        {
            if (userName == null)
            {
                throw new InvalidUserProcessingException();
            }
        }
    }
}
