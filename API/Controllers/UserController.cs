using API.DTO;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDTO>> Create(UserDTO dto)
        {
            var newUser = await _service.CreateAsync(dto);

            return Ok(newUser);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            var users = await _service.FindAllAsync();

            return Ok(users);
        }
    }
}
