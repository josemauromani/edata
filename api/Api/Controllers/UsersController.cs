using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
            _userService = userService;    
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _userService.GetAll();
            if (users == null) return NotFound("Nao ha usuarios cadastrados");
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null) return NotFound("Usuario nao encontrado");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto userDto)
        {
            await _userService.Create(userDto);
            return new CreatedAtRouteResult("GetUser", new { id = userDto.Id }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto userDto)
        {
            await _userService.Update(id, userDto);
            return Ok(userDto);
        }

        [HttpDelete]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            var userDto = await _userService.GetById(id);
            await _userService.Delete(id);
            return Ok(userDto);
        }
    }
}
