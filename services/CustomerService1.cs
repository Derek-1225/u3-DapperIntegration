/* using Orders.Api.models;
using Orders.Api.models.dapper;
using Orders.Api.repository;

namespace Orders.Api.services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IReadOnlyList<Customer>> ListAsync()
        {
            DapperResponse response = await _customerRepository.GetAll();
            if (!response.Success || response.Result is not IEnumerable<Customer> customers)
            {
                return Array.Empty<Customer>();
            }
            return customers.ToList();
        }
        public async Task<Customer?> FindAsync(int id)
        {
            DapperResponse response = await _customerRepository.GetById(id);
            if (!response.Success)
            {
                return null;
            }
            return response.Result as Customer;
        }
    }
} */