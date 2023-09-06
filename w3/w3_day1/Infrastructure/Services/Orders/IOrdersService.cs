using Domain.Entities;
using Domain.Response;

namespace Infrastructure.Services.Orders;

public interface IOrdersService
{
    Task<Response<string>> AddOrder(Orderss orders);
    Task<Response<string>> DeleteOrder(int id);
    Task<Response<string>> UpdateOrder(Orderss orders);
    Task<Response<Orderss>> GetByIdOrder(int id);
    Task<Response<List<Orderss>>> GetOrders();
}