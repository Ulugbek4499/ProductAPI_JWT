using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Application.Services.ManageServices
{
    public partial class ManageUserService
    {
        private static void ValidateUsernameAndPassword(string username, string password)
        {
            if (username == null || password == null)
                throw new ArgumentNullException();

        }
    }
}
