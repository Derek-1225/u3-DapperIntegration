namespace Orders.Api.models.dtos
{
    public sealed class EditOrderDto
    {
        public required string OrderId { get; set; }
        public required string Status { get; set; }
        public required bool HasFinished { get; set; }
    }
}