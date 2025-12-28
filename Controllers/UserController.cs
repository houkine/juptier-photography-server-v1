using jupter_server.Models;
using Microsoft.AspNetCore.Mvc;
using jupter_server.Services;

namespace jupter_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;
        private ILogger<ControllerBase> _logger;
        public UserController(
            ILogger<ControllerBase> logger,
            IUserService userService
         )
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetUsers()
        {
            //return await _context.User.ToListAsync();
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpGet]
        [Route("find")]
        public IActionResult Find([FromQuery] 
            string email="", string name="", string address = "", string DOBstart = "1900-01-01", string DOBend = "2200-01-01", int skip = 0,int take = 20
        )
        {
            return Ok(_userService.Find(email, name, address, DOBstart, DOBend, skip, take));
        }

        [HttpGet]
        [Route("count")]
        public IActionResult Count([FromQuery]
            string email="", string name = "", string address = "", string DOBstart = "1900-01-01", string DOBend = "2200-01-01"
        )
        {
            return Ok(_userService.Count(email, name, address, DOBstart, DOBend));
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserCreateRequest model)
        {
            _userService.Create(model);
            return Ok(new { message = "User created" });
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] AuthenticateRequest model)
        {
            
            return Ok(_userService.Signin(model));
        }

        [HttpPut]
        public IActionResult Update(UserUpdateRequest model)
        {
            _userService.Update(model);
            return Ok(new { message = "User updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted" });
        }
    }
}
