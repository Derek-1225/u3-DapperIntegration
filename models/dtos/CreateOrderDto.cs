using System.ComponentModel.DataAnnotations;

namespace Orders.Api.models.dtos
{
    public sealed class CreateOrderDto
    {
        public required string CustomerCode { get; set; }
        [StringLength(80,MinimumLength=20)]
        public required string Status { get; set; }

        public required bool HasFinished { get; set; }
    }
}