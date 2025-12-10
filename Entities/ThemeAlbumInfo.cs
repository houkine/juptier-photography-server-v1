using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jupter_server.Entities
{
    [Index(nameof(sequence))]
    public class ThemeAlbumInfo : BaseModel
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? coverImage { get; set; }
        public int sequence { get; set; }
        public Guid? GalleryThemeInfoId { get; set; }
        public GalleryThemeInfo? GalleryThemeInfo { get; set; }
        public ICollection<AlbumImageListInfo> AlbumImageListInfos { get; } = new List<AlbumImageListInfo>();
    }
}
