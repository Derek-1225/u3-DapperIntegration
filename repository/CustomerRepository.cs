using System.Data;
using Dapper;
using Orders.Api.models;
using Orders.Api.models.dapper;
using Orders.Api.models.dtos;

namespace Orders.Api.repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDapperService _dapperService;
        private const string ConnectionId = "DefaultConnection";
        public CustomerRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public async Task<DapperResponse> GetAll()
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Customers_GetAll"
            };
            return await _dapperService.ExecuteStoredProcedureAsync<Customer>(
            procedure,
            hasArray: true);
        }
        public async Task<DapperResponse> GetById(int id)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Customers_GetById"
            };
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerId", id);
            return await _dapperService.ExecuteStoredProcedureAsync<Customer>(
            procedure,
            parameters,
            hasArray: false);
        }

        public async Task<DapperResponse> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Customers_Create"
            };
            var parametros = new DynamicParameters();
            parametros.Add("@CustomerCode", createCustomerDto.CustomerCode);
            parametros.Add("@CompanyName ", createCustomerDto.CompanyName);
            parametros.Add("@TaxId", createCustomerDto.TaxId);
            parametros.Add("@ContactName", createCustomerDto.ContactName);
            parametros.Add("@Phone ", createCustomerDto.Phone);
            parametros.Add("@Email", createCustomerDto.Email);
            parametros.Add("@City", createCustomerDto.City);

            parametros.Add(
                "@CustomerId",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output
            );

            return await _dapperService.ExecuteStoredProcedureAsync<Customer>(
            procedure,
            parametros,
            hasArray: false);
        }

        public async Task<DapperResponse> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var procedimiento = new StoredProcedureInf
            {
                IdConnectionString = "DefaultConnection",
                SchemaName = "dbo",
                Name = "usp_Customers_Update"
            };

            var parametros = new DynamicParameters();
            parametros.Add("@CustomerId", updateCustomerDto.CustomerId);
            parametros.Add("@CustomerCode", updateCustomerDto.CustomerCode);
            parametros.Add("@CompanyName ", updateCustomerDto.CompanyName);
            parametros.Add("@TaxId", updateCustomerDto.TaxId);
            parametros.Add("@ContactName", updateCustomerDto.ContactName);
            parametros.Add("@Phone ", updateCustomerDto.Phone);
            parametros.Add("@Email", updateCustomerDto.Email);
            parametros.Add("@City", updateCustomerDto.City);
            parametros.Add("@IsActive", updateCustomerDto.IsActive);

            return await _dapperService.ExecuteStoredProcedureAsync<Customer>(
            procedimiento,
            parametros,
            hasArray: false);
        }

        public async Task<DapperResponse> DeleteCustomer(int id)
        {
            var procedimiento = new StoredProcedureInf
            {
                IdConnectionString = "DefaultConnection",
                SchemaName = "dbo",
                Name = "usp_Customers_Delete"
            };

            var parametros = new DynamicParameters();
            parametros.Add("@CustomerId", id);

            return await _dapperService.ExecuteStoredProcedureAsync<Customer>(
            procedimiento,
            parametros,
            hasArray: false);
        }

    }
}