using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Products_Domain.Models.Permissions;
using Products_Domain.Models.Products;
using Products_Domain.Models.Roles;
using Products_Domain.Models.Users;

namespace Products_Application.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public ValueTask<T> AddAsync<T>(T @object);
        public ValueTask<T> GetAsync<T>(params object[] objectIds) where T : class;
        public IQueryable<T> GetAll<T>() where T : class;
        public ValueTask<T> UpdateAsync<T>(T @object);
        public ValueTask<T> DeleteAsync<T>(T @object);

        //public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
