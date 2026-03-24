using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;



        public UsersController(IUserService userServices) {



            _userService = userServices;

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserResponse>> GetById(Guid id) {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }



        [HttpGet("{id:guid}/exists")]
        public async Task<IActionResult> Exists(Guid id) {


            var exist = await _userService.ExistAsync(id);

            return Ok(new { exist });






        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        {

            var users = await _userService.GetAllAsync();

            return Ok(users);




        }

        


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserResponse?>> UpdateAsync(Guid id, UpdateUserDTO dto) {
            var update = await _userService.UpdateAsync(id, dto);
            if (update == null) return NotFound();
            return Ok(update);
           
        }

        [HttpPost("/Register")]
        public async Task<ActionResult<UserResponse>> Register([FromBody] CreateUserDTO userDTO)
        {

            var CreateUser = await _userService.CreateAsync(userDTO);


            return CreatedAtAction(nameof(GetById), new { id = CreateUser.Id }, CreateUser);
        }


    }
}
