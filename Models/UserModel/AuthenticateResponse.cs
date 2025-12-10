namespace jupter_server.Entities;

using System.ComponentModel.DataAnnotations;

public class AuthenticateResponse 
{
    public User user { get; set; }
    public string token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        this.user = user;
        this.token = token;
    }
}