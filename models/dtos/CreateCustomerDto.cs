using System.ComponentModel.DataAnnotations;

namespace Orders.Api.models.dtos
{
    public sealed class CreateCustomerDto
    {
        [StringLength(20, MinimumLength = 6)]
        public required string CustomerCode { get; set; }
        
        [StringLength(150, MinimumLength = 10)]
        public required string CompanyName { get; set; }
        
        [StringLength(20, MinimumLength = 6)]
        public required string TaxId { get; set; }

        [StringLength(20, MinimumLength = 6)]
        public required string ContactName { get; set; }

        [StringLength(30, MinimumLength = 8)]
        public required string Phone { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(30, MinimumLength = 8)]
        public required string City { get; set; }
    }
}