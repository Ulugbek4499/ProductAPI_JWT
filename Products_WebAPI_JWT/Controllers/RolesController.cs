﻿using Microsoft.AspNetCore.Mvc;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Roles;

namespace Products_WebAPI_JWT.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostRoleAsync(Role role)
        {
            role.Id = Guid.NewGuid();

            Role entity = await _roleService.AddRoleAsync(role);

            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetRoleAsync(Guid id)
        {
            Role entity = await _roleService.GetRoleByIdAsync(id);

            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            IQueryable<Role> entities = _roleService.GetAllRoles();

            return Ok(entities);
        }


        [HttpPut]
        public async ValueTask<IActionResult> PutRoleAsync(Role role)
        {
            Role entity = await _roleService.UpdateRoleAsync(role);

            return Ok(entity);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteRoleAsync(Guid id)
        {
            Role entity = await _roleService.DeleteRoleAsync(id);

            return Ok(entity);
        }
    }
}
