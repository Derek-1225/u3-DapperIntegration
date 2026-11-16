using System.Data;
using Dapper;
using Orders.Api.models;
using Orders.Api.models.dapper;
using Orders.Api.models.dtos;

namespace Orders.Api.repository
{
    public class TransportOrderRepository : ITransportOrderRepository
    {
        private readonly IDapperService _dapperService;

        private const string ConnectionId = "DefaultConnection";

        public TransportOrderRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<DapperResponse> GetAll()
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_GetAll"
            };

            return await _dapperService.ExecuteStoredProcedureAsync<TransportOrder>(
                procedure,
                hasArray: true);
        }

        public async Task<DapperResponse> GetById(int id)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_GetById"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@OrderId", id);

            return await _dapperService.ExecuteStoredProcedureAsync<TransportOrder>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> CreateTransportOrder(CreateTransportOrderDto dto)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_Create"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@OrderNumber", dto.OrderNumber);
            parameters.Add("@CustomerId", dto.CustomerId);
            parameters.Add("@VehicleId", dto.VehicleId);
            parameters.Add("@OriginCity", dto.OriginCity);
            parameters.Add("@DestinationCity", dto.DestinationCity);
            parameters.Add("@CargoDescription", dto.CargoDescription);
            parameters.Add("@WeightKg", dto.WeightKg);
            parameters.Add("@FreightAmount", dto.FreightAmount);
            parameters.Add("@CurrencyCode", dto.CurrencyCode);
            parameters.Add("@Status", dto.Status);
            parameters.Add("@PickupDate", dto.PickupDate);
            parameters.Add("@DeliveryDate", dto.DeliveryDate);
            parameters.Add("@Notes", dto.Notes);

            parameters.Add(
                "@OrderId",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            return await _dapperService.ExecuteStoredProcedureAsync<TransportOrder>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> UpdateTransportOrder(UpdateTransportOrderDto dto)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_Update"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@OrderId", dto.OrderId);
            parameters.Add("@OrderNumber", dto.OrderNumber);
            parameters.Add("@CustomerId", dto.CustomerId);
            parameters.Add("@VehicleId", dto.VehicleId);
            parameters.Add("@OriginCity", dto.OriginCity);
            parameters.Add("@DestinationCity", dto.DestinationCity);
            parameters.Add("@CargoDescription", dto.CargoDescription);
            parameters.Add("@WeightKg", dto.WeightKg);
            parameters.Add("@FreightAmount", dto.FreightAmount);
            parameters.Add("@CurrencyCode", dto.CurrencyCode);
            parameters.Add("@Status", dto.Status);
            parameters.Add("@PickupDate", dto.PickupDate);
            parameters.Add("@DeliveryDate", dto.DeliveryDate);
            parameters.Add("@Notes", dto.Notes);

            return await _dapperService.ExecuteStoredProcedureAsync<TransportOrder>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> DeleteTransportOrder(int id)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_TransportOrders_Delete"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@OrderId", id);

            return await _dapperService.ExecuteStoredProcedureAsync<TransportOrder>(
                procedure,
                parameters,
                hasArray: false);
        }
    }
}