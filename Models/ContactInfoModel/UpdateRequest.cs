namespace jupter_server.Models.ContactInfoModel;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest : BaseUpdateRequest
{
    public string? Background { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}