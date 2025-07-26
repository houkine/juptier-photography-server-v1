namespace jupter_server.Models.Users;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest: UpdateRequestBase
{
    public string email { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    public string dateOfBirth { get; set; }
    public string address { get; set; }
    public string name { get; set; }
}