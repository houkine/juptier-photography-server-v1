namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class AlbumImageInfoUpdateRequest : BaseUpdateRequest
{
    public string? src { get; set; }
    public int sequence { get; set; } = 0;

}