namespace Infrastructure.Services.Generics;

public interface IBaseServices<T>
{
    Task<Responce<T>> GetAll();
    Task<Responce<T>> GetById(int id);
    Task<Responce<T>> Add(T obj);
    Task<Responce<T>> Update(T obj);
    Task<Responce<T>> Delete(int id);
}