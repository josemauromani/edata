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
    }
}
