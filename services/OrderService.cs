using Orders.Api.models;
using Orders.Api.models.dtos;

namespace Orders.Api.services
{
    public class OrderService : IOrderService
    {
        //Creacion de Listas Estáticas
        static List<Order> orders =
        [
            new(){
            Id=Guid.NewGuid().ToString(),
            CustomerCode="Walmart",
            Status="In Transit",
            HasFinished = true
            },
            new(){
                Id=Guid.NewGuid().ToString(),
                CustomerCode="Jumex",
                Status="Dispatched"
            },
            new(){
                Id=Guid.NewGuid().ToString(),
                CustomerCode="Mercado Libre",
                Status="Lost",
                HasFinished=true
            }
        ];
        //La firma consiste en una tupla de parametros de salida y en el metodo hay un parametro de entrada
        public (bool HasError, string? OrderId) CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                var orderId = Guid.NewGuid().ToString();
                orders.Add(new Order
                {
                    Id = orderId,
                    CustomerCode = createOrderDto.CustomerCode,
                    Status = createOrderDto.Status,
                    HasFinished = createOrderDto.HasFinished
                });
                return (false, orderId);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                //Devuelve los parametros de salida
                return (true, null);
            }
        }

        public List<Order> GetFinishedOrders()
        {
            return [..orders.Where(order => order.HasFinished == true)];
        }

        public int GetOrdersCount()
        {
            return orders.Count;
        }

        public (bool HasError, string? Message) EditOrder(EditOrderDto editOrderDto)
        {
            int index = orders.FindIndex(x=> x.Id == editOrderDto.OrderId);
            try
            {
                orders[index].Status = editOrderDto.Status;
                orders[index].HasFinished = editOrderDto.HasFinished;
                return (false,"Objeto editado con exito");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return (true, "Hubo un error al editar");
            }
        }
    }
}