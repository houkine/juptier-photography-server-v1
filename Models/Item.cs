using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace jupter_server.Models
{
    public class Item : BaseModel
    {
        public string name { get; set; }
        public float price { get; set; }
        public string? description { get; set; }
        public string? detail { get; set; }
        public string? imgSrc { get; set; }
        public string? includings { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    } 
}
