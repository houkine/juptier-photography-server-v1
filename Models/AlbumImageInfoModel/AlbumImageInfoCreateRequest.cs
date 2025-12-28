namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class AlbumImageInfoCreateRequest : BaseCreateRequest
{

    public string? src { get; set; }
    public int sequence { get; set; } = 0;

    public Guid AlbumImageListInfoId { get; set; }


}