using Microsoft.Data.SqlClient;
using Npgsql;

namespace DbTwin.Utils;

public static class DatabaseConnector
{
    public static void TestSqlConnection(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("SQL Server connection string is missing.");
            return;
        }

        try
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("SQL Server connection successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SQL Server connection failed: {ex.Message}");
        }
    }

    public static void TestNpgsqlConnection(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("PostgreSQL connection string is missing.");
            return;
        }

        try
        {
            using var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("PostgreSQL connection successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"PostgreSQL connection failed: {ex.Message}");
        }
    }
}