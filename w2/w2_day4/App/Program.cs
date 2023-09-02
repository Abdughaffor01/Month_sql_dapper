using Domein.Model;
using Infrastructure.Services;

CategoryService categoryService = new CategoryService();
QuotesService quotesService =new QuotesService();
while(true){
    Console.WriteLine();
    Console.WriteLine("comands : category , quotes , another req");
    string com=Console.ReadLine();
    if(com.ToLower().Trim()=="category"){
        while(true){
            Console.WriteLine("Category command : add,delete,getall,getbyid,update,home");
            string comm=Console.ReadLine();
            if(comm.ToLower().Trim()=="add"){
                Category category=new Category();
                Console.Write("Enter category name : ");
                category.Name=Console.ReadLine();
                var res=await categoryService.Add(category);
                Console.WriteLine(res.Message);  
            }else if(comm.ToLower().Trim()=="delete"){
                Console.Write("Enter id category : ");
                int id=Convert.ToInt32(Console.ReadLine());
                var res= await categoryService.Delete(id);
                Console.WriteLine(res.Message);
            }else if(comm.ToLower().Trim()=="getall"){
                var res= await categoryService.GetAll();
                if(res.Datas==null)Console.WriteLine(res.Message);
                else foreach (var i in res.Datas) Console.WriteLine($"id {i.Id} name : {i.Name} ");
            }else if(comm.ToLower().Trim()=="getbyid"){
                Console.Write("Enter id category : ");
                int id=Convert.ToInt32(Console.ReadLine());
                var res= await categoryService.GetById(id);
                if(res.Data==null)Console.WriteLine(res.Message);
                else Console.WriteLine($"id {res.Data.Id} name : {res.Data.Name} ");
            }else if(comm.ToLower().Trim()=="update"){
                Category category=new Category();
                Console.Write("Enter id category : ");
                category.Id=Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter name category : ");
                category.Name=Console.ReadLine();
                var res=await categoryService.Update(category);
                Console.WriteLine(res.Message);
            }else if(comm.ToLower().Trim()=="home")break;
             else Console.WriteLine("error command");
        }
    }else Console.WriteLine("not found");
}


