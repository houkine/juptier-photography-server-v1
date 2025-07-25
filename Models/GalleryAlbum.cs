using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace jupter_server.Models
{
    public class GalleryAlbum : BaseModel
    {
        public string name { get; set; }
        public string? introduce { get; set; }

        public Guid? GalleryId { get; set; }
        public Gallery? Gallery { get; set; }
        public ICollection<Photo> Photos { get; } = new List<Photo>();

    }
}
