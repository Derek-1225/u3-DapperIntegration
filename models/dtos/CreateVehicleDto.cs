namespace Orders.Api.models.dtos
{
    public class CreateVehicleDto
    {
        public string PlateNumber { get; set; } = string.Empty;

        public string VehicleType { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public short ModelYear { get; set; }

        public decimal CapacityTons { get; set; }

        public string Status { get; set; } = string.Empty;

    }
}