using jupter_server.Helpers;
using jupter_server.Models;
using jupter_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace jupter_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GalleryThemeInfoController : ControllerBase
    {

        private IGalleryThemeInfoService _service;
        private ILogger<ControllerBase> _logger;
        public GalleryThemeInfoController(
            ILogger<ControllerBase> logger,
            IGalleryThemeInfoService service
         )
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var records = _service.GetAll();
            return Ok(records);
        }

        [HttpGet]
        [Route("getall/{GalleryId}")]
        public IActionResult GetAll(Guid GalleryId)
        {
            var records = _service.GetAll(GalleryId);
            return Ok(records);
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
        [Route("getbytitle/{title}")]
        public IActionResult GetByTitle(string title)
        {
            try
            {
                return Ok(_service.GetByTitle(title));
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

        

        [HttpPost]
        public IActionResult Create([FromBody] GalleryThemeInfoCreateRequest model)
        {
            try
            {
                _service.Create(model);
                return Ok(new { message = "Theme created" });
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
        public IActionResult Update(GalleryThemeInfoUpdateRequest model)
        {
            try {
                _service.Update(model);
                return Ok(new { message = "Theme updated" });
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
            return Ok(new { message = "Theme deleted" });
        }
    }
}
