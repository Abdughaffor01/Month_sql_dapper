namespace Domain.Response;

public class Response<T>
{
    public string Mesagge { get; set; }
    public T Data { get; set; }
    public Response(string mesagge) => Mesagge = mesagge;
    public Response(string mesagge,T data)
    {
        Mesagge = mesagge;
        Data = data;
    }
}