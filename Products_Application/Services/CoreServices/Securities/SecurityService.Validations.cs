using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Application.Services.CoreServices.Securities.Exceptions;
using Products_Domain.Models.Users;

namespace Products_Application.Services.CoreServices.Securities
{
    public partial class SecurityService
    {
        private static void ValidateUser(User user) 
        {
            ValidateUserIsNotNull(user);
            IsInvalid(user.UsersId);
            IsInvalid(user.Username);
            IsInvalid(user.Password);
        }

        private static void IsInvalid(Guid userId)
        {
            if (userId == default)
            {
                throw new InvalidUserException();
            }
        }

        private static void IsInvalid(string text)
        {
            if (text == null)
            {
                throw new InvalidUserException();
            }
        }


        private static void ValidateUserIsNotNull(User user)
        {
            if (user == null)
            {
                throw new InvalidUserException();
            }
        }
    }
}
