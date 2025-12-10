using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jupter_server.Entities
{
    public class AboutInfo : BaseModel
    {
        public string? imageSrc { get; set; }
        public string? Title { get; set; }
        public string? WorkContent { get; set; }
        public string? ContactContent { get; set; }

    }
}
