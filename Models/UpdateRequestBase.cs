using System.ComponentModel.DataAnnotations;

public class UpdateRequestBase
{
[Required]
    public Guid Id { get; set; }
        public Boolean IsValid { get; set; } = true;
public string? Reserve { get; set; }

}