using Orders.Api.models;
using Orders.Api.models.dtos;

namespace Orders.Api.services
{
    public interface IOrderService
    {        
        // ? indica si el valor es nulo o no
        (bool HasError, string? OrderId) CreateOrder(CreateOrderDto createOrderDto);
        List<Order> GetFinishedOrders();
        int GetOrdersCount();
        (bool HasError,string? Message) EditOrder(EditOrderDto editOrderDto);
    }
}