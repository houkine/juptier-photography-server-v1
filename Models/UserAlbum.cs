
namespace jupter_server.Models
{
    public class UserAlbum : BaseModel
    {
        public string name { get; set; }
        public string? introduce { get; set; }

        public ICollection<Photo> Photos { get; } = new List<Photo>();
    } 
}
