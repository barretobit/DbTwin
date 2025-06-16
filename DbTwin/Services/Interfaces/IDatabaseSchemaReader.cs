using DbTwin.Models;

namespace DbTwin.Services.Interfaces;

public interface IDatabaseSchemaReader
{
    List<TableInfo> GetTables();

    List<ColumnInfo> GetTableColumns(string schema, string tableName);

    List<IndexInfo> GetTableIndexes(string schema, string tableName);
}