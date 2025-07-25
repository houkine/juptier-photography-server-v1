using jupter_server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using jupter_server.Models.Users;

namespace jupter_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<ControllerBase> _logger;
        private readonly ApplicationDbContext _context;
        public UserController(ILogger<ControllerBase> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRequest model)
        {
            return Ok(new
            {
                model
            });
        }

        
        private static UserDTO UserToDTO(User user) =>
       new UserDTO
       {
           Id = user.Id,
           email = user.email,
           name = user.name,
       };
    }
    public class TestModel
    {
        public string id { get; set; }
    }
}
