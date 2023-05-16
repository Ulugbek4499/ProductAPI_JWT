using System.Runtime.Serialization;

namespace Products_Application.Services.CoreServices.Securities.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException() : base("Invalid User! Please check and try one more time!")
        { }      
    }
}