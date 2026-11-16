namespace Orders.Api.models
{
    //Las clases selladas son aquellas que no pueden ser heredadas
    public sealed class Order
    {
        //Required elimina la adevertencia de nulo
        public required string Id { get; set; }
        public required string CustomerCode { get; set; }
        public required string Status { get; set; }
        public bool HasFinished { get; set; } = false;
    }   
}