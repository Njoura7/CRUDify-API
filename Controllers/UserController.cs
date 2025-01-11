using CRUDify_API.Data;
using CRUDify_API.Models;
using CRUDify_API.DTOs;
using CRUDify_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDify_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult> AddUserAsync([FromBody] UserDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                // Return validation errors to the frontend
                return BadRequest(ModelState);
            }
            await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserDTO userDto)
        {
            if (id != userDto.Id)
                return BadRequest("User ID mismatch.");

            try
            {
                await _userService.UpdateUserAsync(id, userDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }


        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }


    }
}
