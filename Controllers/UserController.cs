using blogAPI.Data;
using blogAPI.Dto.User;
using Microsoft.AspNetCore.Mvc;
namespace blogAPI.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public IActionResult AddUser(CreateUserDto CreateUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    DisplayName = CreateUserDto.DisplayName,
                    Email = CreateUserDto.Email,
                    Phone = CreateUserDto.Phone,
                    Address = CreateUserDto.Address,
                    DateOfBirth = CreateUserDto.DateOfBirth
                };
                var createUser = _userRepository.InsertUser(user);
                return Ok(createUser);

            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListUser()
        {
            var listUser = await _userRepository.GetListUser();
            return Ok(listUser);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(Guid Id, PutUserDto PutUserDto)
        {
            if (ModelState.IsValid)
            {
                var userNew = new User()
                {
                    DisplayName = PutUserDto.DisplayName,
                    Email = PutUserDto.Email,
                    Phone = PutUserDto.Phone,
                    Address = PutUserDto.Address,
                    DateOfBirth = PutUserDto.DateOfBirth
                };
                return Ok(await _userRepository.EditUser(Id, userNew));

            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return Ok(await _userRepository.DeleteUser(id));
        }


    }
}