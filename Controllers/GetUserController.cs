using CRUDify_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDify_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserController : ControllerBase
    {
        private static readonly string[] Colors = new[]
        {
            "Blue", "Red", "Green", "Black", "White", "Black"
        };

 

        [HttpGet(Name = "GetUser")]
        public IEnumerable<User> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new User
            {
                Name = "Njoura",
                Age = Random.Shared.Next(1, 100),
                Color = Colors[Random.Shared.Next(Colors.Length)]
            })
            .ToArray();
        }
    }
}
