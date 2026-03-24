using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly JwtServices _jwtService;
        
        public AuthController(JwtServices jwtServices, IUserService userService) { 
        
        _jwtService = jwtServices;
        _userService = userService;
        
       
        
        
        
        
        
        }

        [HttpPost("login")]

        public async Task<ActionResult> AuthenticateAsync([FromBody ]LoginDto dto)
        {
            var user = await _userService.GetByEmailAsync(dto);

            if (user == null) { 
            
            return Unauthorized();
            
            }

            var token = _jwtService.GenerateToken(user.Id, user.Email, user.Role);


            return Ok( new { token });




        }



    }
}
