using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Products_Application.DTOs.Permissions;
using Products_Application.DTOs.Products;
using Products_Application.DTOs.Roles;
using Products_Application.DTOs.Users;
using Products_Domain.Models.Permissions;
using Products_Domain.Models.Products;
using Products_Domain.Models.Roles;
using Products_Domain.Models.Users;

namespace Products_Infrastructure.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Permission, CreatePermissionDTO>().ReverseMap();
            CreateMap<Permission, ReadPermissionDTO>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDTO>().ReverseMap();
            CreateMap<Permission, DeletePermissionDTO>().ReverseMap();
     
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ReadProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, DeleteProductDTO>().ReverseMap();

            CreateMap<Role, CreateRoleDTO>().ReverseMap();
            CreateMap<Role, ReadRoleDTO>().ReverseMap();
            CreateMap<Role, UpdateRoleDTO>().ReverseMap();
            CreateMap<Role, DeleteRoleDTO>().ReverseMap();
          
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, ReadUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<User, DeleteUserDTO>().ReverseMap();
        }
    }
}
