using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Orders.Api.models.dtos
{
    public sealed class UpdateCustomerDto
    {
        public required int CustomerId { get; set; }

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

        [Range(0,1)]
        public required int IsActive { get; set; }
    }
}