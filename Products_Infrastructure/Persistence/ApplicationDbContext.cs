using Microsoft.EntityFrameworkCore;
using Products_Application.Abstraction;
using Products_Domain.Models.Permissions;
using Products_Domain.Models.Products;
using Products_Domain.Models.Roles;
using Products_Domain.Models.Users;

namespace Products_Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext 
    {
        private  DbContextOptions<ApplicationDbContext> options;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.options = options;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<RolePermission>().HasKey(x => new
            {
                x.RoleId,
                x.PermissionId
            });

            modelBuilder.Entity<RolePermission>()
                        .HasOne(x=>x.Role).WithMany(x=>x.RolePermissions)
                        .HasForeignKey(x=>x.RoleId);

            modelBuilder.Entity<RolePermission>()
                        .HasOne(x => x.Permission).WithMany(x => x.RolePermissions)
                        .HasForeignKey(x => x.PermissionId);

           
            modelBuilder.Entity<UserRole>().HasKey(x => new
            {
                x.UserId,
                x.RoleId
            });

            modelBuilder.Entity<UserRole>()
                        .HasOne(x => x.User).WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRole>()
                        .HasOne(x => x.Role).WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.RoleId);
        }

        public async ValueTask<T> AddAsync<T>(T @object)
        {
            var context = new ApplicationDbContext(options);
            Entry(@object).State = EntityState.Added;
            await SaveChangesAsync();

            return @object;
        }

        public async ValueTask<T> DeleteAsync<T>(T @object)
        {
            var context = new ApplicationDbContext(options);
            context.Entry(@object).State = EntityState.Deleted;
            await context.SaveChangesAsync();

            return @object;
        }

        public  IQueryable<T> GetAll<T>() where T : class
        {
            var context = new ApplicationDbContext(options);
            return context.Set<T>();
        }

        public async ValueTask<T> GetAsync<T>(params object[] objectIds) where T : class
        {
            var context = new ApplicationDbContext(options);
            return await context.FindAsync<T>(objectIds);
        }

        public async ValueTask<T> UpdateAsync<T>(T @object)
        {
            var context = new ApplicationDbContext(options);
            context.Entry(@object).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return @object;
        }
    }
}
