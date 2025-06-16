using DbTwin;
using DbTwin.Services;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var appSettings = configuration.Get<AppSettings>();

        if (appSettings == null || appSettings.ConnectionStrings == null || string.IsNullOrEmpty(appSettings.DatabaseEngine))
        {
            Console.WriteLine("Configuration is missing or invalid.");
            return;
        }

        Console.WriteLine($"--- Analyzing Engine: {appSettings.DatabaseEngine} ---");

        if (appSettings.DatabaseEngine.ToUpperInvariant() == "SQL")
        {
            // 1. Read schemas from both databases
            var db1Reader = new SqlServerSchemaReader(appSettings.ConnectionStrings.Database1!);
            var db1Tables = db1Reader.GetTables();

            var db2Reader = new SqlServerSchemaReader(appSettings.ConnectionStrings.Database2!);
            var db2Tables = db2Reader.GetTables();

            // 2. Perform the comparison using the new service
            SchemaComparer.CompareTables(db1Tables, db2Tables);
        }
        else
        {
            Console.WriteLine("PostgreSQL analysis not implemented yet.");
        }

        Console.WriteLine("\nReady for the next step.");
    }
}