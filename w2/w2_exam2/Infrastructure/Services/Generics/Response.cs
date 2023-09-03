namespace Infrastructure.Services.Generics;
public class Responce<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public List<T> Datas { get; set; }
    public Responce(string message)=>Message=message;
    public Responce(string message,List<T> datas)
    {
        Message=message;
        Datas=datas;
    }
    public Responce(string message,T data)
    {
        Message=message;
        Data=data;
    }
}