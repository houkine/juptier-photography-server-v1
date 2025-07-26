namespace jupter_server.Models.Users;

using System.ComponentModel.DataAnnotations;

public class CreateRequest:CreaseRequestBase
{
    [Required]
    public string email { get; set; }

    [Required]
    public string password { get; set; }

    [Required]
    public string name { get; set; }

    public DateTime? dateOfBirth { get; set; }

    public string address { get; set; }

    
}