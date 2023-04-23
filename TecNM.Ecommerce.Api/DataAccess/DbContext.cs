using System.Data.Common;
using MySqlConnector;
using TecNM.Ecommerce.Api.DataAccess.Interfaces;

namespace TecNM.Ecommerce.Api.DataAccess;

public class DbContext : IDbContext
{
    private readonly string _connectionString = "server=localhost;user=root;database=TWM;password=ChilaquilesRojos";

    private MySqlConnection _connection;

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            return _connection;
        }
    }
}