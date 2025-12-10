namespace jupter_server.Entities
{
    public class UserAlbum : BaseModel
    {
        public string name { get; set; }
        public string? introduce { get; set; }

        public ICollection<Photo> Photos { get; } = new List<Photo>();
    } 
}
