namespace Orders.Api.models
{
    public class TransportOrder
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public int CustomerId { get; set; }

        public int? VehicleId { get; set; }

        public string OriginCity { get; set; } = string.Empty;

        public string DestinationCity { get; set; } = string.Empty;

        public string CargoDescription { get; set; } = string.Empty;

        public decimal WeightKg { get; set; }

        public decimal FreightAmount { get; set; }

        public string CurrencyCode { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime PickUpDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}