namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class ThemeAlbumInfoCreateRequest : BaseCreateRequest
{

    public string? title { get; set; }
    public string? description { get; set; }
    public string? coverImage { get; set; }
    public int sequence { get; set; } = 0;

    public Guid GalleryThemeInfoId { get; set; }


}