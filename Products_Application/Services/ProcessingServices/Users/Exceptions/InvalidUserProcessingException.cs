using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Application.Services.ProcessingServices.Users.Exceptions
{
    public  class InvalidUserProcessingException:Exception
    {
        public InvalidUserProcessingException():base("Invalid username or password. Please check one more time!")
        {}
    }
}
