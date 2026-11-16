namespace Orders.Api.models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerCode { get; set; }

        public string CompanyName { get; set; }

        public string TaxId { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}