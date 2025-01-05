using CRUDify_API.Data;
using CRUDify_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDify_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        private readonly DataContext _context;

        public AddUserController(DataContext context)
        {
            _context = context;
            
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.Users.Add(user); 
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());    
        }
    }
}
