namespace Infrastructure.Services.Generic
{
    interface  IbaseService<T>
    {
        Task<Response<T>> GetAll();
        Task<Response<T>> GetById(int id);
        Task<Response<T>> Add(T entity);
        Task<Response<T>> Update(T entity);
        Task<Response<T>> Delete(int id);
    }
}
