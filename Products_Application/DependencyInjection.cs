using Microsoft.Extensions.DependencyInjection;
using Products_Application.Interfaces.CoreServiceInterfaces;
using Products_Application.Interfaces.ManageServiceInterfaces;
using Products_Application.Interfaces.ProcessingServiceInterfaces.Users;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Application.Interfaces.TokenInterfaces;
using Products_Application.Services.CoreServices.Permissions;
using Products_Application.Services.CoreServices.ProductServices;
using Products_Application.Services.CoreServices.Roles;
using Products_Application.Services.CoreServices.Securities;
using Products_Application.Services.CoreServices.UserServices;
using Products_Application.Services.ManageServices;
using Products_Application.Services.ProcessingServices.Users;
using Products_Application.Tokens.TokenServices;

namespace Products_Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionProcessingService, UserProcessingService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IManageUserServiceInterface, ManageUserService>();
            services.AddTransient<IJwtToken, JwtToken>();

            return services;
        }
    }
}
