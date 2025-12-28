using jupter_server.Entities;
using jupter_server.Helpers;
using jupter_server.Models;
using jupter_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace jupter_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThemeAlbumInfoController : ControllerBase
    {

        private IThemeAlbumInfoService _service;
        private ILogger<ControllerBase> _logger;
        public ThemeAlbumInfoController(
            ILogger<ControllerBase> logger,
            IThemeAlbumInfoService service
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
        [Route("getall/{GalleryThemeInfoId}")]
        public IActionResult GetAll(Guid GalleryThemeInfoId)
        {
            var records = _service.GetAll(GalleryThemeInfoId);
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
        public IActionResult Create([FromBody] ThemeAlbumInfoCreateRequest model)
        {
            try
            {
                _service.Create(model);
                return Ok(new { message = "Album created" });
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
        public IActionResult Update(ThemeAlbumInfoUpdateRequest model)
        {
            try {
                _service.Update(model);
                return Ok(new { message = "Album updated" });
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
            return Ok(new { message = "Album deleted" });
        }
    }
}
