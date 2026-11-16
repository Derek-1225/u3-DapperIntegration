using Orders.Api.models.dapper;
using Orders.Api.models.dtos;

namespace Orders.Api.repository
{
    public interface ICustomerRepository
    {
        Task<DapperResponse> GetAll();
        Task<DapperResponse> GetById(int id);
        Task<DapperResponse> CreateCustomer(CreateCustomerDto createCustomerDto);
        Task<DapperResponse> UpdateCustomer(UpdateCustomerDto updateCustomerDto);
        Task<DapperResponse> DeleteCustomer(int id);
    }
}