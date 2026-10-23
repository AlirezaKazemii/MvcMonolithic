namespace MvcMonolithic.Models.DomainModels.ProductAggregate
{
    public class Product
    {
        public Product()
        {
            
        }

        public Product(string productName, string productDescription, decimal unitPrice, int quantity)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }


        public void UpdateProduct(
            string productName,
            string  productDescription,
            decimal unitPrice,
            int quantity)
        {
            ProductName = productName;
            ProductDescription= productDescription;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}