using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user != null ? Ok(user) : NotFound("User not found");
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest user)
    {
        var newUser = await _userService.AddAsync(user);
        return Ok(newUser);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest user)
    {
        if (id != user.Id)
        {
            return BadRequest("User ID mismatch");
        }

        var updatedUser = await _userService.UpdateAsync(user);
        return updatedUser != null ? Ok(updatedUser) : NotFound("User not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}

