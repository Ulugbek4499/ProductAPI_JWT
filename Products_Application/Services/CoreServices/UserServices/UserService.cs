using Products_Application.Abstraction;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Users;

namespace Products_Application.Services.CoreServices.UserServices
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext applicationDbContext;

        public UserService(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            user.UsersId = new Guid();
            return await applicationDbContext.AddAsync(user);
        }

        public IQueryable<User> GetAllUsers() =>
            applicationDbContext.GetAll<User>();

        public async ValueTask<User> GetUserByIdAsync(Guid id) =>
            await applicationDbContext.GetAsync<User>(id);

        public async ValueTask<User> UpdateUserAsync(User user) =>
            await applicationDbContext.UpdateAsync(user);

        public async ValueTask<User> DeleteUserAsync(Guid id)
        {
            User maybeUser = await applicationDbContext.GetAsync<User>(id);

            if (maybeUser == null)
                throw new ArgumentNullException(nameof(maybeUser));

            return await applicationDbContext.DeleteAsync(maybeUser);
        }
    }
}
