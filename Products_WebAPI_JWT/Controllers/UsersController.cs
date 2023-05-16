using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products_Application.DTOs.Users;
using Products_Application.Interfaces.ManageServiceInterfaces;
using Products_Application.Interfaces.ProcessingServiceInterfaces.Users;
using Products_Application.Interfaces.ServiceInterfaces;
using Products_Domain.Models.Tokens;
using Products_Domain.Models.Users;

namespace Products_WebAPI_JWT.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPermissionProcessingService _userProcessingService;
        private readonly IManageUserServiceInterface _manageUserServiceInterface;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, 
                               IPermissionProcessingService userProcessingService,
                               IManageUserServiceInterface manageUserServiceInterface,
                               IMapper mapper)
        {
            _userProcessingService = userProcessingService;
            _manageUserServiceInterface = manageUserServiceInterface;
            _userService = userService;
            _mapper = mapper;
        }

       
        [HttpPost]
        [AllowAnonymous]
        public async ValueTask<IActionResult> PostUserAsync(CreateUserDTO userDto)
        {
            User user = _mapper.Map<User>(userDto);

            User isUserExists = _userProcessingService.GetUserByUserName(user.Username);

            if (isUserExists!=null)
            {
                return BadRequest();
            }

            await _userService.AddUserAsync(user);

            return Ok(userDto);
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetUserAsync(Guid id)
        {
            User entity = await _userService.GetUserByIdAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            ReadUserDTO readUserDTO = _mapper.Map<ReadUserDTO>(entity);
            return Ok(readUserDTO);
        }

        [HttpGet]
        [Authorize(Roles = "get_all_users")]
        public IActionResult GetUserAsync()
        {
            IQueryable<User> entities = _userService.GetAllUsers();

            List<ReadUserDTO> readUserDTOs = _mapper.Map<List<ReadUserDTO>>(entities);

            return Ok(readUserDTOs);
        }

        [HttpPut]
        public async ValueTask<IActionResult> PutUserAsync(UpdateUserDTO updateUserDTO)
        {
            User user = _mapper.Map<User>(updateUserDTO);

            await _userService.UpdateUserAsync(user);

            return Ok(updateUserDTO);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUserAsync(Guid id)
        {
            User entity = await _userService.DeleteUserAsync(id);

            return Ok(entity);
        }

        [HttpPost("login"), AllowAnonymous]
        public IActionResult LoginAsync(UserCredentials userCredentials)
        {
            User maybeUser =
              _userProcessingService
                .GetUserByUserCredentials(userCredentials);

            if (maybeUser == null)
            {
                return NotFound(userCredentials);
            }

            UserToken userToken =
              _manageUserServiceInterface.CreateUserToken(maybeUser);

            return Ok(userToken);
        }
    }
}
