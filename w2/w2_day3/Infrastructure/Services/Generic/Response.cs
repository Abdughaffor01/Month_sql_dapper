namespace Infrastructure.Services.Generic
{
    public class Response<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> Datas { get; set; }
        public Response(string message)=>Message = message;
        public Response(string message,T data)
        {
            Message = message;
            Data = data;    
        }
        public Response(string message, List<T> datas)
        {
            Message = message;
            Datas = datas;
        }
    }
}
