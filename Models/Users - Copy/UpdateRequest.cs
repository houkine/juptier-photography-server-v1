namespace jupter_server.Models.Users;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    
}