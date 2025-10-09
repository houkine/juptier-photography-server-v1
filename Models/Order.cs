using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using jupter_server.Models.UserModel;

namespace jupter_server.Models
{
    public class Order: BaseModel
    {
        public float price { get; set; }
        public string? session { get; set; }
        public int? photoAmount { get; set; }
        public DateTime? bookingTime { get; set; }
        public string? postscript { get; set; }
        public string? status { get; set; }

        public required Guid ItemId { get; set; } 
        public required Item Item { get; set; }

        public required Guid UserId { get; set; }
        public required User User { get; set; }
    }
}
