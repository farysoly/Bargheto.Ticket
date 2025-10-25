using AppService.Interfaces.Users;
using Contract.Users;
using Contract.Users.Commands;
using EndPoint.Services;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers.Users;

[ApiController]
[Route("auth")]
public class AuthController(IUserService userService, JwtService jwt) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        try
        {
            if (req == null || string.IsNullOrEmpty(req.Email) || string.IsNullOrEmpty(req.Password))
                return BadRequest(new { message = "Email and Password are required." });

            var user = await userService.Execute(req);
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var token = jwt.GenerateToken(user);

            return Ok(new LoginResponse
            {
                Token = token,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred during login" });
        }
    }

    //[Authorize(Roles = "ADMIN")]
    //[HttpPost("Register")]
    //public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    //{
    //    await userService.Execute(command);
    //    return Ok();
    //}
}
