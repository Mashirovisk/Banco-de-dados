using Microsoft.Data.Sqlite;

namespace ScreenSound3.Database;

public class ConnectionFactory
{
    private SqliteConnection? _connection;

    public SqliteConnection GetConnection()
    {
        if(_connection == null)
        {
            _connection = new SqliteConnection("Data Source=Screensound.db;");
            _connection.Open();
        }
        return _connection;
    }
}
