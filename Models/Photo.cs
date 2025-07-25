using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace jupter_server.Models
{
    [Index(nameof(sequence))]
    public class Photo : BaseModel
    {
        public string url { get; set; }
        public string? name { get; set; }
        public int? sequence { get; set; }

        public ICollection<Order> GalleryAlbums { get; } = new List<Order>();
        public ICollection<Order> UserAlbums { get; } = new List<Order>();
    } 
}
