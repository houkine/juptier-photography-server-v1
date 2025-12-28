// theme

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jupter_server.Entities
{
    [Index(nameof(sequence))]
    public class GalleryThemeInfo : BaseModel
    {
        public string? title { get; set; }
        public string? description { get; set; }

        // not been used so far
        public string? coverImage { get; set; }
        public int sequence { get; set; }


        public Guid? GalleryId { get; set; }
        public Gallery? Gallery { get; set; }
        public ICollection<ThemeAlbumInfo> ThemeAlbumInfos { get; } = new List<ThemeAlbumInfo>();

    }
}
