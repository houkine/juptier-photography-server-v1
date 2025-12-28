namespace jupter_server.Models;

using System.ComponentModel.DataAnnotations;

public class ContactInfoUpdateRequest : BaseUpdateRequest
{
    public string? Background { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}