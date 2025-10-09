using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jupter_server.Models
{
    public class BaseUpdateRequest
    {
        [Required]
        public Guid id { get; set; }
        public Boolean isValid { get; set; } 
        public string? Reserve { get; set; }

    }
}
