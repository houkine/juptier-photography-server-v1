using Microsoft.Extensions.Configuration;

namespace jupter_server.Helpers;

public class AppSettings
{
    public string Secret { get; set; } = "secret";
}