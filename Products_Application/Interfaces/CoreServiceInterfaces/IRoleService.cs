using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_Domain.Models.Roles;

namespace Products_Application.Interfaces.ServiceInterfaces
{
    public interface IRoleService
    {
        ValueTask<Role> AddRoleAsync(Role role);
        IQueryable<Role> GetAllRoles();
        ValueTask<Role> GetRoleByIdAsync(Guid id);
        ValueTask<Role> UpdateRoleAsync(Role role);
        ValueTask<Role> DeleteRoleAsync(Guid id);
    }
}
