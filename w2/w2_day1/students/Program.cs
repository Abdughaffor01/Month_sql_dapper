using students.model;
using Univer.service;

StudentsService studentsService=new StudentsService();
while (true)
{
    Console.WriteLine("Pres 1 add student");
    Console.WriteLine("Pres 2 update student");
    Console.WriteLine("Pres 3 delete student");
    Console.WriteLine("Pres 4 exit");
    int num=Convert.ToInt32(Console.ReadLine());
    if (num == 1)
    {
        Student student = new Student();
        Console.Write("Firstname : ");
        student.Firstname = Console.ReadLine();
        Console.Write("Lastname : ");
        student.Lastname = Console.ReadLine();
        Console.Write("Age : ");
        student.Age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Email : ");
        student.Email = Console.ReadLine();
        studentsService.Add(student);
        
    } else if (num == 2)
    {
        Console.Write("id studenta : ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Firstname : ");
        string firstname = Console.ReadLine();
        Console.Write("Lastname : ");
        string lastname = Console.ReadLine();
        Console.Write("Age : ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Email : ");
        string gmail = Console.ReadLine();
        Console.WriteLine(add());
        string add()
        {
            using (var con = new NpgsqlConnection(c))
            {
                var res = con.Execute($"update student set firstname='{firstname}',lastname='{lastname}',age='{age}',gmail='{gmail}' where id={id}");
                if (res == 1) return "update  shid";
                return "Nashid";
            }
        }
    }else if (num == 3){
        Console.Write("id studenta : ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(add());
        string add()
        {
            using (var con = new NpgsqlConnection(c))
            {
                var res = con.Execute($"delete from student where id={id}");
                if (res == 1) return "delete  shid";
                return "Nashid";
            }
        }
    }
    else if (num == 4) break;
}


