using Dapper;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Context;

namespace Infrastructure.Services.Orders;
public class OrdersService:IOrdersService
{
    private readonly DataContext _dataContext;
    public OrdersService() => _dataContext = new DataContext();
    public async Task<Response<string>> AddOrder(Orderss orders)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"insert into orders(user_id,product,quantity) values({orders.UserId},'{orders.Product}',{orders.Quantity})";
            var res = await con.ExecuteAsync(sql);
            if (res==0) return new Response<string>("error");
            return new Response<string>("Successful added");
        }
        catch (Exception e)
        {
            return new Response<string>(e.Message);
        }
    }
    public async Task<Response<string>> DeleteOrder(int id)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"delete from orders where id={id}";
            var res = await con.ExecuteAsync(sql);
            if (res==0) return new Response<string>("error");
            return new Response<string>("Successful deleted");
        }
        catch (Exception e)
        {
            return new Response<string>(e.Message);
        }
    }
    public async Task<Response<string>> UpdateOrder(Orderss orders)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"update orders set user_id={orders.UserId},product={orders.Product},quantity={orders.Quantity}";
            var res = await con.ExecuteAsync(sql);
            if (res==0) return new Response<string>("error");
            return new Response<string>("Successful updated");
        }
        catch (Exception e)
        {
            return new Response<string>(e.Message);
        }
    }
    public async Task<Response<Orderss>> GetByIdOrder(int id)
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"select id as Id,user_id as UserId,product as Product,quantity as Quantity from orders where id={id}";
            var res = await con.QueryFirstOrDefaultAsync<Orderss>(sql);
            if (res==null) return new Response<Orderss>("error");
            return new Response<Orderss>("Successful order found",res);
        }
        catch (Exception e)
        {
            return new Response<Orderss>(e.Message);
        }
    }
    public async Task<Response<List<Orderss>>> GetOrders()
    {
        try
        {
            using var con = _dataContext.CreateContext();
            string sql = $"select id as Id,user_id as UserId,product as Product,quantity as Quantity from orders ";
            var res = await con.QueryAsync<Orderss>(sql);
            if (res==null) return new Response<List<Orderss>>("error");
            return new Response<List<Orderss>>("Successful orders found",res.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Orderss>>(e.Message);
        }
    }
}