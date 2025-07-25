using jupter_server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using jupter_server.Models.Users;

namespace jupter_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        private readonly ApplicationDbContext _context;
        public TestController(ILogger<TestController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GeTestMessage")]
        public string Get()
        {
            User user = new();
            user.email = "email.com";
            user.name = "pan";
            _context.User.Add(user);
            _context.SaveChanges();
            return "success";
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            //Console.WriteLine(model);
            return Ok(new { message = model.FirstName });
        }
    }
}
