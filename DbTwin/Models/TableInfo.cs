namespace DbTwin.Models;

public class TableInfo : IEquatable<TableInfo>
{
    public string TableName { get; set; } = string.Empty;
    public string Schema { get; set; } = string.Empty;

    public bool Equals(TableInfo? other)
    {
        if (other is null)
            return false;

        // Two tables are considered equal if they have the same schema and name.
        return Schema == other.Schema && TableName == other.TableName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as TableInfo);
    }

    public override int GetHashCode()
    {
        // Generate a hash code based on the schema and name.
        return HashCode.Combine(Schema, TableName);
    }
}