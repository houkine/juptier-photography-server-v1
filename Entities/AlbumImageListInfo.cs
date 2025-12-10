using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jupter_server.Entities
{
    [Index(nameof(sequence))]
    public class AlbumImageListInfo : BaseModel
    {
        public int sequence { get; set; }

        public Guid? ThemeAlbumInfoId { get; set; }
        public ThemeAlbumInfo? ThemeAlbumInfo { get; set; }
        public ICollection<AlbumImageInfo> AlbumImageInfos { get; } = new List<AlbumImageInfo>();
    }
}
