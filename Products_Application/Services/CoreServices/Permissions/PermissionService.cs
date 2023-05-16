using Products_Application.Abstraction;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Permissions;

namespace Products_Application.Services.CoreServices.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IApplicationDbContext applicationDbContext;

        public PermissionService(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async ValueTask<Permission> AddPermissionAsync(Permission permission)
        {
            permission.Id = new Guid();
           return await applicationDbContext.AddAsync(permission);
        }

        public IQueryable<Permission> GetAllPermissions() =>
            applicationDbContext.GetAll<Permission>();

        public async ValueTask<Permission> GetPermissionByIdAsync(Guid id) =>
            await applicationDbContext.GetAsync<Permission>(id);

        public async ValueTask<Permission> UpdatePermissionAsync(Permission permission) =>
            await applicationDbContext.UpdateAsync(permission);

        public async ValueTask<Permission> DeletePermissionAsync(Guid id)
        {
            Permission maybePermission = await applicationDbContext.GetAsync<Permission>(id);

            if (maybePermission == null)
                throw new ArgumentNullException(nameof(maybePermission));

            return await applicationDbContext.DeleteAsync(maybePermission);
        }

        public object AddPermissionAsync(List<Permission> permissions)
        {
            throw new NotImplementedException();
        }
    }
}
