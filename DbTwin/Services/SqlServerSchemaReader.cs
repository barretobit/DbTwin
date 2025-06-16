using DbTwin.Models;
using DbTwin.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace DbTwin.Services;

public class SqlServerSchemaReader : IDatabaseSchemaReader
{
    private readonly string _connectionString;

    public SqlServerSchemaReader(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public List<TableInfo> GetTables()
    {
        var tables = new List<TableInfo>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var command = new SqlCommand("SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            tables.Add(new TableInfo
            {
                Schema = reader["TABLE_SCHEMA"].ToString()!,
                TableName = reader["TABLE_NAME"].ToString()!
            });
        }
        return tables;
    }

    public List<ColumnInfo> GetTableColumns(string schema, string tableName)
    {
        var columns = new List<ColumnInfo>();
        // Implementation for getting columns will go here in the next step.
        return columns;
    }

    public List<IndexInfo> GetTableIndexes(string schema, string tableName)
    {
        var indexes = new List<IndexInfo>();
        // Implementation for getting indexes will go here in the next step.
        return indexes;
    }
}