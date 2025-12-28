namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class ThemeAlbumInfoUpdateRequest : BaseUpdateRequest
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? coverImage { get; set; }
    public int sequence { get; set; } = -1;


}