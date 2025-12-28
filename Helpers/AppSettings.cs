using Microsoft.Extensions.Configuration;

namespace jupter_server.Helpers;

public class AppSettings
{
    public string Secret { get; set; } = "secret";
    public Guid DefaultGuid { get; set; } = Guid.Parse("00000000-0000-0000-0000-000000000000");
    public int AlbumListLength { get; set; } = 3;
}