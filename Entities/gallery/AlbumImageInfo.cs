using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jupter_server.Entities
{
    [Index(nameof(sequence))]
    public class AlbumImageInfo : BaseModel
    {
        public string? src { get; set; }
        public int sequence { get; set; }

        public Guid AlbumImageListInfoId { get; set; }
        public AlbumImageListInfo AlbumImageListInfo { get; set; }
    }
}
