using System.Data;
using Npgsql;
namespace Infrastructure.Context;
public class DataContext
{
    private string cons = "Server=localhost;Port=5432;Database=magazin;User Id=postgres;Password=987849660;";
    public IDbConnection CreateContext() => new NpgsqlConnection(cons);
}