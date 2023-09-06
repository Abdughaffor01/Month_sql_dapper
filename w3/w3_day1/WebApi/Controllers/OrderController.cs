namespace WebApi.Controllers;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Services.Orders;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrderController:ControllerBase
{
    private readonly OrdersService _ordersService;
    public OrderController() => _ordersService = new OrdersService();
    
    [HttpPost("AddOrder")]
    public async Task<Response<string>> AddOrder(Orderss order) => await _ordersService.AddOrder(order);

    [HttpDelete("DeleteOrder")]
    public async Task<Response<string>> DeleteOrder(int id) => await _ordersService.DeleteOrder(id);

    [HttpPut("UpdateOrder")]
    public async Task<Response<string>> UpdateOrder(Orderss order) => await _ordersService.UpdateOrder(order);

    [HttpGet("GetByIdOrder")]
    public async Task<Response<Orderss>> GetByIdOrder(int id) => await _ordersService.GetByIdOrder(id);

    [HttpGet("GetOrders")]
    public async Task<Response<List<Orderss>>> GetOrders() => await _ordersService.GetOrders();
}