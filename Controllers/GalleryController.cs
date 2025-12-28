using jupter_server.Helpers;
using jupter_server.Models;
using jupter_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace jupter_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GalleryController : ControllerBase
    {

        private IGalleryService _service;
        private ILogger<ControllerBase> _logger;
        public GalleryController(
            ILogger<ControllerBase> logger,
            IGalleryService service
         )
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_service.GetById(id));

            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case KeyNotFoundException:
                        return NotFound(ex.Message);

                    default:
                        return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        [Route("getbyname/{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(_service.GetByName(name));
        }

        

        [HttpPost]
        public IActionResult Create([FromBody] GalleryCreateRequest model)
        {
            try
            {
                _service.Create(model);
                return Ok(new { message = "Gallery created" });
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case AppException:
                        return BadRequest(ex.Message);

                    default:
                        return BadRequest(ex.Message);
                }
            }
            
        }


        [HttpPut]
        public IActionResult Update(GalleryUpdateRequest model)
        {
            try {
                _service.Update(model);
                return Ok(new { message = "Gallery updated" });
            }
            catch (Exception ex) {
                switch (ex)
                {
                    case AppException:
                        return BadRequest(ex.Message);

                    default:
                        return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return Ok(new { message = "Gallery deleted" });
        }
    }
}
