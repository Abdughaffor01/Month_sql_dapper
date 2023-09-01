using Domein.Model;
using Infrastructure.Services;
StudentService studentService= new StudentService();
while (true) {
    try
    {
        Console.WriteLine("Press 1 add student");
        Console.WriteLine("Press 2 getbyid student");
        Console.WriteLine("Press 3 get all student");
        Console.WriteLine("Press 4 update student");
        Console.WriteLine("Press 5 delete student");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        if (num == 1)
        {
            Student student = new Student();
            Console.Write("Firstname : ");
            student.FirstName = Console.ReadLine();
            Console.Write("Lastname : ");
            student.LastName = Console.ReadLine();
            Console.Write("Age : ");
            student.Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Email : ");
            student.Email = Console.ReadLine();
            var res = await studentService.Add(student);
            Console.WriteLine(res.Message);
            Console.WriteLine();
        }
        else if (num == 2)
        {
            Console.Write("Enter id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var res = await studentService.GetById(id);
            if (res.Data == null) Console.WriteLine(res.Message);
            else Console.WriteLine($"{res.Data.FirstName} {res.Data.LastName} age={res.Data.Age} email={res.Data.Email}");
            Console.WriteLine();
        }
        else if (num == 3)
        {
            var res = await studentService.GetAll();
            if (res.Datas == null) Console.WriteLine(res.Message);
            else
            {
                foreach (var i in res.Datas)
                {
                    Console.WriteLine($"{i.Id} {i.FirstName} {i.LastName} age={i.Age} email={i.Email}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
        else if (num == 4)
        {
            Student student = new Student();
            Console.Write("Id student : ");
            student.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Firstname : ");
            student.FirstName = Console.ReadLine();
            Console.Write("Lastname : ");
            student.LastName = Console.ReadLine();
            Console.Write("Age : ");
            student.Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Email : ");
            student.Email = Console.ReadLine();
            var res = await studentService.Update(student);
            Console.WriteLine(res.Message);
            Console.WriteLine();
        }
        else if (num == 5) {
            Console.Write("Enter id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var res =await studentService.Delete(id);
            Console.WriteLine(res.Message);
        }
        else Console.WriteLine("Eror comand");
    }
    catch
    {
      Console.WriteLine("Erorr enter again");
    }
}
