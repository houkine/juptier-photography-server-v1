namespace jupter_server.Models.GalleryModel;

using System.ComponentModel.DataAnnotations;

public class CreateRequest:BaseCreateRequest
{

    public string? name { get; set; }
    public string? backgroundImage { get; set; }


}