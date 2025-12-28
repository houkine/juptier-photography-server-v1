using jupter_server.Entities;
using jupter_server.Helpers;
using jupter_server.Models;
using jupter_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace jupter_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumImageInfoController : ControllerBase
    {

        private IAlbumImageInfoService _service;
        private ILogger<ControllerBase> _logger;
        public AlbumImageInfoController(
            ILogger<ControllerBase> logger,
            IAlbumImageInfoService service
         )
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        [Route("getall/{AlbumImageListInfoId}")]
        public IActionResult GetAll(Guid AlbumImageListInfoId)
        {
            var records = _service.GetAll(AlbumImageListInfoId);
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


        [HttpPut]
        public IActionResult BulkUpdate(AlbumImageInfoBulkUpdateRequest model)
        {
            try {
                _service.BulkUpdate(model.newData, model.ThemeAlbumInfoId);
                return Ok(new { message = "Images updated" });
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
            return Ok(new { message = "Image deleted" });
        }

        public class AlbumImageInfoBulkUpdateRequest
        {
            public AlbumImageInfoCreateRequest[] newData { get; set; }
            public Guid ThemeAlbumInfoId { get; set; }

        }
    }
}
