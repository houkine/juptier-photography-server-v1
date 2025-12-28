namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;
using jupter_server.Entities;

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