using DbTwin;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Map configuration to our AppSettings class
        var appSettings = configuration.Get<AppSettings>();

        // Output the connection strings to verify
        Console.WriteLine("--- DbTwin Initialized ---");
        Console.WriteLine($"Database 1 Connection String: {appSettings?.ConnectionStrings?.Database1}");
        Console.WriteLine($"Database 2 Connection String: {appSettings?.ConnectionStrings?.Database2}");
        Console.WriteLine("--------------------------");

        Console.WriteLine("\nReady for the next step.");
    }
}