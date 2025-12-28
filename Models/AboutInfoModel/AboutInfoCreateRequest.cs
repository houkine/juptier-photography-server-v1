namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class AboutInfoCreateRequest : BaseCreateRequest
{

    public string? imageSrc { get; set; }
    public string? Title { get; set; }
    public string? WorkContent { get; set; }
    public string? ContactContent { get; set; }


}