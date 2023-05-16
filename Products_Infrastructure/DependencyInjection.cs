using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products_Application.Abstraction;
using Products_Infrastructure.Mapping;
using Products_Infrastructure.Persistence;

namespace Products_Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ProductJWTConnection"));
            });

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
