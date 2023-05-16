using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Domain.Models.Permissions;

namespace Products_Application.Interfaces.ServiceInterfaces
{
    public interface IPermissionService
    {
        ValueTask<Permission> AddPermissionAsync(Permission permission);
        IQueryable<Permission> GetAllPermissions();
        ValueTask<Permission> GetPermissionByIdAsync(Guid id);
        ValueTask<Permission> UpdatePermissionAsync(Permission permission);
        ValueTask<Permission> DeletePermissionAsync(Guid id);
        object AddPermissionAsync(List<Permission> permissions);
    }
}
