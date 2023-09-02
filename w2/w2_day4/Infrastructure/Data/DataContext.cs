using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
        string connectionString="Server=localhost;Port=5432;Database=Quetion;User Id=postgres;Password=987849660;";
        public NpgsqlConnection _DataContext()=>new NpgsqlConnection(connectionString);
}
