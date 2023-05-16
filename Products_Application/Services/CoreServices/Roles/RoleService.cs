using Products_Application.Abstraction;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Roles;

namespace Products_Application.Services.CoreServices.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IApplicationDbContext applicationDbContext;

        public RoleService(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<Role> AddRoleAsync(Role role) =>
            await applicationDbContext.AddAsync(role);

        public IQueryable<Role> GetAllRoles() =>
            applicationDbContext.GetAll<Role>();

        public async ValueTask<Role> GetRoleByIdAsync(Guid id) =>
            await applicationDbContext.GetAsync<Role>(id);

        public async ValueTask<Role> UpdateRoleAsync(Role role) =>
            await applicationDbContext.UpdateAsync(role);

        public async ValueTask<Role> DeleteRoleAsync(Guid id)
        {
            Role maybeRole = await applicationDbContext.GetAsync<Role>(id);

            if (maybeRole == null)
                throw new ArgumentNullException(nameof(maybeRole));

            return await applicationDbContext.DeleteAsync(maybeRole);
        }
    }
}
