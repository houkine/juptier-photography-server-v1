namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class GalleryCreateRequest : BaseCreateRequest
{

    public string name { get; set; }
    public string? backgroundImage { get; set; }

    public GalleryCreateRequest(string name)
    {

        this.name = name;
    }
}