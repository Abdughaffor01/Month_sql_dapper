using Dapper;
using Npgsql;
using students.model;

namespace Univer.service
{
    public class StudentsService
    {
        string c = "Server=localhost;Port=5432;Database=students;User Id=postgres;Password=987849660;";
        public async Task<string> Add(Student student) { 
            return await Task.Run(() => {
                using (var con = new NpgsqlConnection(c))
                {
                    var res = con.Execute($"insert into student(firstname,lastname,age,gmail)values('{student.Firstname}','{student.Lastname}',{student.Age},'{student.Email}')");
                    if (res == 1) return "Dob shid";
                    return "Nashid";
                }
            });
        }

    }
}
