namespace DbTwin;

public class AppSettings
{
    public string? DatabaseEngine { get; set; }
    public ConnectionStrings? ConnectionStrings { get; set; }
}

public class ConnectionStrings
{
    public string? Database1 { get; set; }
    public string? Database2 { get; set; }
}