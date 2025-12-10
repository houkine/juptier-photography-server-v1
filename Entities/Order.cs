using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using jupter_server.Models.UserModel;

namespace jupter_server.Entities
{
    public class Order: BaseModel
    {
        public float price { get; set; }
        public string? session { get; set; }
        public int? photoAmount { get; set; }
        public DateTime? bookingTime { get; set; }
        public string? postscript { get; set; }
        public string? status { get; set; }

        public Guid? ItemId { get; set; } 
        public Item? Item { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
