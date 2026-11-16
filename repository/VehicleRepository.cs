using System.Data;
using Dapper;
using Orders.Api.models;
using Orders.Api.models.dapper;
using Orders.Api.models.dtos;

namespace Orders.Api.repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDapperService _dapperService;

        private const string ConnectionId = "DefaultConnection";

        public VehicleRepository(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<DapperResponse> GetAll()
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Vehicles_GetAll"
            };

            return await _dapperService.ExecuteStoredProcedureAsync<Vehicle>(
                procedure,
                hasArray: true);
        }

        public async Task<DapperResponse> GetById(int id)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Vehicles_GetById"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@VehicleId", id);

            return await _dapperService.ExecuteStoredProcedureAsync<Vehicle>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> CreateVehicle(CreateVehicleDto createVehicleDto)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Vehicles_Create"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@PlateNumber", createVehicleDto.PlateNumber);
            parameters.Add("@VehicleType", createVehicleDto.VehicleType);
            parameters.Add("@Brand", createVehicleDto.Brand);
            parameters.Add("@Model", createVehicleDto.Model);
            parameters.Add("@ModelYear", createVehicleDto.ModelYear);
            parameters.Add("@CapacityTons", createVehicleDto.CapacityTons);
            parameters.Add("@Status", createVehicleDto.Status);

            parameters.Add(
                "@VehicleId",
                dbType: DbType.Int32,
                direction: ParameterDirection.Output);

            return await _dapperService.ExecuteStoredProcedureAsync<Vehicle>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Vehicles_Update"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@VehicleId", updateVehicleDto.VehicleId);
            parameters.Add("@PlateNumber", updateVehicleDto.PlateNumber);
            parameters.Add("@VehicleType", updateVehicleDto.VehicleType);
            parameters.Add("@Brand", updateVehicleDto.Brand);
            parameters.Add("@Model", updateVehicleDto.Model);
            parameters.Add("@ModelYear", updateVehicleDto.ModelYear);
            parameters.Add("@CapacityTons", updateVehicleDto.CapacityTons);
            parameters.Add("@Status", updateVehicleDto.Status);
            parameters.Add("@IsActive", updateVehicleDto.IsActive);

            return await _dapperService.ExecuteStoredProcedureAsync<Vehicle>(
                procedure,
                parameters,
                hasArray: false);
        }

        public async Task<DapperResponse> DeleteVehicle(int id)
        {
            var procedure = new StoredProcedureInf
            {
                IdConnectionString = ConnectionId,
                SchemaName = "dbo",
                Name = "usp_Vehicles_Delete"
            };

            var parameters = new DynamicParameters();

            parameters.Add("@VehicleId", id);

            return await _dapperService.ExecuteStoredProcedureAsync<Vehicle>(
                procedure,
                parameters,
                hasArray: false);
        }
    }
}