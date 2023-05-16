using Products_Application.Interfaces.CoreServiceInterfaces;
using Products_Application.Interfaces.ManageServiceInterfaces;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Application.Services.CoreServices.UserServices;
using Products_Domain.Models.Tokens;
using Products_Domain.Models.Users;

namespace Products_Application.Services.ManageServices
{
    public partial class ManageUserService : IManageUserServiceInterface
    {
        private readonly IUserService userService;
        private readonly ISecurityService securityService;

        public ManageUserService(IUserService userService, ISecurityService securityService)
        {
            this.userService = userService;
            this.securityService = securityService;
        }

        public UserToken CreateUserToken(User user)
        {
            string username= user.Username;
            string password= user.Password;   

            ValidateUsernameAndPassword(username, password);
           
            ValidateUserExists(user);

            string token=securityService.CreateToken(user);

            return new UserToken()
            {
                UserID = user.UsersId,
                Token = token
            };
        }

        private static void ValidateUserExists(User user)
        {
            if(user is null)
                throw new ArgumentNullException(nameof(user));
        }

        public User GetUserByUserCredentials(string username, string password)
        {
            ValidateUsernameAndPassword(username, password);
            IQueryable<User> allUsers = userService.GetAllUsers();

            return allUsers.FirstOrDefault(x => x.Username.Equals(username)
                            && x.Password.Equals(password));
        }
    }
}
