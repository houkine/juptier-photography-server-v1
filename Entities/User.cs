using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jupter_server.Entities
{
    [Index(nameof(email))]
    public class User : BaseModel
    {
        public string email { get; set; } = "";

        public string? password { get; set; }
        public string? name { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string? address { get; set; }
        public string? gender { get; set; } //more than male and female
        public string? interest { get; set; } //

        public ICollection<Order> Orders { get; } = new List<Order>();

        //public User() {

        //    this.IsValid = true;
        //}
    }
}
