using Products_Application.Interfaces.ProcessingServiceInterfaces.Users;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Users;

namespace Products_Application.Services.ProcessingServices.Users
{
    public partial class UserProcessingService : IPermissionProcessingService
    {
        private readonly IUserService userService;

        public UserProcessingService(IUserService userService)
        {
            this.userService = userService;
        }

        public User GetUserByUserCredentials(UserCredentials userCredentials)
        {
            string username = userCredentials.Username;
            string password = userCredentials.Password;


            ValidateUsernameAndPassword(username, password);
            IQueryable<User> allUsers = userService.GetAllUsers();

            return allUsers.FirstOrDefault(x => x.Username.Equals(username)
                            && x.Password.Equals(password));
        }

        public User GetUserByUserName(string userName)
        {
            ValidateUsername(userName);

            IQueryable<User> allUsers = userService.GetAllUsers();

            return allUsers.FirstOrDefault(x => x.Username.Equals(userName));
        }
    }
}
