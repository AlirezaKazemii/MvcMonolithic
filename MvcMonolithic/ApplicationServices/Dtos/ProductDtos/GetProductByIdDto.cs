namespace MvcMonolithic.ApplicationServices.Dtos.ProductDtos
{
    public class GetProductByIdDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
