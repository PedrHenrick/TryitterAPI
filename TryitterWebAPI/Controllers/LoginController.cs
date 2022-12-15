using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryitterWebAPI.Models;
using TryitterWebAPI.Interfaces;
using TryitterWebAPI.Repository;

namespace TryitterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public UserController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var token = await _loginRepository.TokenGenerate(login.Email, login.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Token not generated, invalid credentials. Please try again.");
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            _loginRepository.CreateStudent(student);
            return CreatedAtAction("Get", new { id = student.StudentId }, student);
        }
    }
}
