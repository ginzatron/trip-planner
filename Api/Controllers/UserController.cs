using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(new { status = "ok" });
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(new { status = "ok" });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            return Ok(new { status = "ok" });
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            return Ok(new { status = "ok" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(new { status = "ok" });
        }
    }
}
