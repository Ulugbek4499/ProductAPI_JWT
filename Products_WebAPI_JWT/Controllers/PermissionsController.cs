using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products_Application.DTOs.Permissions;
using Products_Application.Interfaces.ManageServiceInterfaces;
using Products_Application.Interfaces.ProcessingServiceInterfaces.Users;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Permissions;
using Serilog;

namespace Products_WebAPI_JWT.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionsController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }
                
        [HttpPost]
        public async ValueTask<IActionResult> PostPermissionAsync(CreatePermissionDTO permissionDTO)
        {
            Permission permission= _mapper.Map<Permission>(permissionDTO);

            Permission entity = await
              _permissionService.AddPermissionAsync(permission);

            return Ok(permissionDTO);
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetPermissionAsync(Guid id)
        {
            Permission entity = await _permissionService.GetPermissionByIdAsync(id);

            if (entity == null)
            {
                Log.Fatal("Fata Error Occuring On Get Permission By Id Method");
                return BadRequest();    
            }

            ReadPermissionDTO permissionDTO = _mapper.Map<ReadPermissionDTO>(entity);

            return Ok(permissionDTO);
        }

        [HttpGet]
        public IActionResult GetAllPermissionsAsync()
        {
            IQueryable<Permission> entities = _permissionService.GetAllPermissions();

            List<ReadPermissionDTO> permissionDTOs = _mapper.Map<List<ReadPermissionDTO>>(entities);

            return Ok(permissionDTOs);
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutPermissiosAsync(UpdatePermissionDTO updatePermissionDTO)
        {
            Permission entity = _mapper.Map<Permission>(updatePermissionDTO);

            await _permissionService.UpdatePermissionAsync(entity);

            return Ok(updatePermissionDTO);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeletePermissionAsync(Guid id)
        {
            Permission entity = await
              _permissionService.DeletePermissionAsync(id);

            DeletePermissionDTO deletePermissionDTO=_mapper.Map<DeletePermissionDTO>(entity);

            return Ok(deletePermissionDTO);
        }
    }
}
