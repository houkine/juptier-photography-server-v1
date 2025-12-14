namespace jupter_server.Models.GalleryModel;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest : BaseUpdateRequest
{
    public string? name { get; set; }
    public string? backgroundImage { get; set; }
}