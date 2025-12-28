namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class GalleryUpdateRequest : BaseUpdateRequest
{
    public string? name { get; set; }
    public string? backgroundImage { get; set; }
}