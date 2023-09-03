
using Domein.Model;
using Infrastructure.Services;

DTOServices dtoServices = new DTOServices();
GroupService groupService = new GroupService();
StudentService studentService = new StudentService();
while (true)
{
    Console.WriteLine("Command : group ,student , service");
    string command = Console.ReadLine();
    if (command.ToLower().Trim() == "group")
    {
        while (true)
        {
            Console.WriteLine("command group : add,delete,update,getall,getbyid");
            string comand = Console.ReadLine();
            if (comand.ToLower().Trim() == "add")
            {
                Groups groups = new Groups();
                Console.Write("GroupName : ");
                groups.GroupsName = Console.ReadLine();
                Console.Write("Grouptitle : ");
                groups.Title = Console.ReadLine();
                var res = await groupService.Add(groups);
                Console.WriteLine(res.Message);
            }
            else if (comand.ToLower().Trim() == "delete")
            {
                Console.Write("Id group : ");
                int id = Convert.ToInt32(Console.ReadLine());
                var res = await groupService.Delete(id);
                Console.WriteLine(res.Message);
            }
            else if (comand.ToLower().Trim() == "update")
            {
                Groups groups = new Groups();
                Console.Write("Id group : ");
                groups.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("GroupName : ");
                groups.GroupsName = Console.ReadLine();
                Console.Write("Grouptitle : ");
                groups.Title = Console.ReadLine();
                var res = await groupService.Update(groups);
                Console.WriteLine(res.Message);
            }
            else if (comand.ToLower().Trim() == "getall")
            {
                var res = await groupService.GetAll();
                if (res.Datas == null) Console.WriteLine(res.Message);
                else
                {
                    foreach (var i in res.Datas)
                    {
                        Console.WriteLine($"-----{i.GroupsName} {i.Title}");
                    }
                }
            }
            else if (comand.ToLower().Trim() == "getbyid")
            {
                Console.WriteLine("Id group");
                int id = Convert.ToInt32(Console.ReadLine());
                var res = await groupService.GetById(id);
                if (res.Data == null) Console.WriteLine(res.Message);
                else
                {
                    Console.WriteLine($"-----{res.Data.Title} {res.Data.GroupsName} {res.Data.Title}");
                }
            }
            else if (comand.ToLower().Trim() == "break") break;
            else Console.WriteLine("error comand");
        }
    }
    else if (command.ToLower().Trim() == "student")
    {
        while (true)
        {
            Console.WriteLine("command student : add,delete,update,getall,getbyid");
            string comand = Console.ReadLine();
            if (comand.ToLower().Trim() == "add")
            {
                Student student = new Student();
                Console.Write("Firstname : ");
                student.FirstName = Console.ReadLine();
                Console.Write("Lastname : ");
                student.LastName = Console.ReadLine();
                Console.Write("Phone : ");
                student.Phone = Console.ReadLine();
                Console.Write("id group : ");
                student.GroupId = Convert.ToInt32(Console.ReadLine());
                var res = await studentService.Add(student);
                Console.WriteLine(res.Message);
            }
            else if (comand.ToLower().Trim() == "delete")
            {
                Console.Write("Id student : ");
                int id = Convert.ToInt32(Console.ReadLine());
                var res = await studentService.Delete(id);
                Console.WriteLine(res.Message);
            }
            else if (comand.ToLower().Trim() == "update")
            {
                Student student = new Student();
                Console.Write("Id student : ");
                student.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Firstname : ");
                student.FirstName = Console.ReadLine();
                Console.Write("Lastname : ");
                student.LastName = Console.ReadLine();
                Console.Write("Phone : ");
                student.Phone = Console.ReadLine();
                Console.Write("id group : ");
                student.GroupId = Convert.ToInt32(Console.ReadLine());
                var res = await studentService.Update(student);
                Console.WriteLine(res.Message);
            }
            else if (comand.ToLower().Trim() == "getall")
            {
                var res = await studentService.GetAll();
                if (res.Datas == null) Console.WriteLine(res.Message);
                else
                {
                    foreach (var i in res.Datas)
                    {
                        Console.WriteLine($"-----{i.FirstName} {i.LastName} {i.Phone} {i.GroupId}");
                    }
                }
            }
            else if (comand.ToLower().Trim() == "getbyid")
            {
                Console.WriteLine("Id student");
                int id = Convert.ToInt32(Console.ReadLine());
                var res = await studentService.GetById(id);
                if (res.Data == null) Console.WriteLine(res.Message);
                else
                {
                    Console.WriteLine(
                        $"-----{res.Data.FirstName} {res.Data.LastName} {res.Data.Phone} {res.Data.GroupId}");
                }
            }
            else if (comand.ToLower().Trim() == "break") break;
            else Console.WriteLine("error comand");
        }
    }
    else if (command.ToLower().Trim() == "service")
    {
        while (true)
        {
            Console.WriteLine("Pres 1 GetStudentByGroup");
            Console.WriteLine("Pres 2 GetRandomStudent");
            Console.WriteLine("Pres 3 GetStudentGroup");
            Console.WriteLine("Pres 4 GroupsWithStudents");
            Console.WriteLine("Pres 5 GroupsByIdWithStudents");
            int comand = Convert.ToInt32(Console.ReadLine());
            if (comand == 1)
            {
                Console.WriteLine("Id groupd");
                int id = Convert.ToInt32(Console.ReadLine());
                var res = await dtoServices.GetStudentByGroup(id);
                Console.WriteLine(res.Message);
                foreach (var i in res.Datas)
                {
                    Console.WriteLine($"-----{i.FirstName} {i.LastName} {i.Phone} {i.GroupId}");
                }
            }
            else if (comand == 2)
            {
                var res = await dtoServices.GetRandomStudent();
                Console.WriteLine(res.Message);
                Console.WriteLine($"-----{res.Data.FirstName} {res.Data.LastName} {res.Data.Phone} {res.Data.GroupId}");
            }
            else if (comand == 3)
            {
                var res = await dtoServices.GetStudentGroup();
                Console.WriteLine(res.Message);
                foreach (var i in res.Datas)
                {
                    Console.WriteLine($"-----{i.FullName} in group {i.GroupName}");
                }
            }
            else if (comand == 4)
            {
                var res = await dtoServices.GroupsWithStudents();
                Console.WriteLine(res.Message);
                foreach (var g in res.Data.Groups)
                {
                    Console.WriteLine(g.GroupsName);
                    var student = res.Data.Student.FindAll(x => x.GroupId == g.Id);
                    foreach (var s in student)
                    {
                        Console.WriteLine($"-----{s.FirstName} {s.LastName} {s.Phone} {s.GroupId}");
                    }
                }
            }
            else if (comand == 5)
            {
                Console.WriteLine("Id group");
                int id = Convert.ToInt32(Console.ReadLine());
                var res = await dtoServices.GroupsByIdWithStudents(id);
                Console.WriteLine(res.Message);
                Console.WriteLine(res.Data.GroupName);
                foreach (var s in res.Data.Students)
                {
                    Console.WriteLine($"-----{s}");
                }
            }else Console.WriteLine("Error command");
        }
    }
    else Console.WriteLine("Error comand");
}