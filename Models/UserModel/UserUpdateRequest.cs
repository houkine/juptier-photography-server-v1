namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class UserUpdateRequest : BaseUpdateRequest
{
    public string? email { get; set; }
    public string? password { get; set; }
    public string? name { get; set; }
    public DateTime? dateOfBirth { get; set; }
    public string? address { get; set; }
}