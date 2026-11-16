using Orders.Api.models.dapper;
using Orders.Api.models.dtos;

namespace Orders.Api.repository
{
    public interface IVehicleRepository
    {
        Task<DapperResponse> GetAll();

        Task<DapperResponse> GetById(int id);

        Task<DapperResponse> CreateVehicle(CreateVehicleDto createVehicleDto);

        Task<DapperResponse> UpdateVehicle(UpdateVehicleDto updateVehicleDto);

        Task<DapperResponse> DeleteVehicle(int id);
    }
}