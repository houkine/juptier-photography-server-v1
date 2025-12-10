namespace jupter_server.Models.AboutInfoModel;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest: BaseUpdateRequest
{
    public string? imageSrc { get; set; }
    public string? Title { get; set; }
    public string? WorkContent { get; set; }
    public string? ContactContent { get; set; }
}