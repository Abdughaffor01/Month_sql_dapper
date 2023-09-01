using Dapper;
using Npgsql;
string c = "Server=localhost;Port=5432;Database=students;User Id=postgres;Password=987849660;";
while (true)
{
    Console.Write("Name : ");
    string name = Console.ReadLine();
    string add()
    {
        using (var con = new NpgsqlConnection(c))
        {
            var res = con.Execute($"insert into student(name) values('{name}')");
            if (res == 1) return "Dob shid";
            return "Nashid";
        }
    }
    Console.WriteLine(add());
    Console.WriteLine();
}
