namespace jupter_server.Models.UserModel;

using System.ComponentModel.DataAnnotations;

public class CreateRequest:BaseCreateRequest
{
    [Required]
    public string email { get; set; }

    [Required]
    public string password { get; set; }

    [Required]
    public string name { get; set; }

    public DateTime? dateOfBirth { get; set; }

    public string? address { get; set; }

    
}