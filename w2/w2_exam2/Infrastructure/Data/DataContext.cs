using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    string conn="Server=localhost;Port=5432;Database=Students;User Id=postgres;Password=987849660;";
    public IDbConnection createcontext()=> new NpgsqlConnection(conn);
}
