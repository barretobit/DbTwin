using DbTwin.Models;

namespace DbTwin.Services;

public static class SchemaComparer
{
    /// <summary>
    /// Compares two lists of tables and prints the differences.
    /// </summary>
    /// <param name="db1Tables">List of tables from Database 1 (source of truth)</param>
    /// <param name="db2Tables">List of tables from Database 2 (comparison target)</param>
    public static void CompareTables(List<TableInfo> db1Tables, List<TableInfo> db2Tables)
    {
        Console.WriteLine("\n--- 1. Comparing Tables ---");

        var missingInDb2 = db1Tables.Except(db2Tables).ToList();
        var extraInDb2 = db2Tables.Except(db1Tables).ToList();

        if (!missingInDb2.Any() && !extraInDb2.Any())
        {
            Console.WriteLine("[OK] Table lists match perfectly.");
        }
        else
        {
            if (missingInDb2.Any())
            {
                Console.WriteLine("[MISMATCH] Tables missing in Database 2:");
                foreach (var table in missingInDb2)
                {
                    Console.WriteLine($"  - {table.Schema}.{table.TableName}");
                }
            }

            if (extraInDb2.Any())
            {
                Console.WriteLine("[MISMATCH] Tables found only in Database 2:");
                foreach (var table in extraInDb2)
                {
                    Console.WriteLine($"  - {table.Schema}.{table.TableName}");
                }
            }
        }
        Console.WriteLine("---------------------------");
    }
}