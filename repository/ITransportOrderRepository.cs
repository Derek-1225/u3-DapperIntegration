using Orders.Api.models.dapper;
using Orders.Api.models.dtos;

namespace Orders.Api.repository
{
    public interface ITransportOrderRepository
    {
        Task<DapperResponse> GetAll();

        Task<DapperResponse> GetById(int id);

        Task<DapperResponse> CreateTransportOrder(CreateTransportOrderDto createTransportOrderDto);

        Task<DapperResponse> UpdateTransportOrder(UpdateTransportOrderDto updateTransportOrderDto);

        Task<DapperResponse> DeleteTransportOrder(int id);
    }
}