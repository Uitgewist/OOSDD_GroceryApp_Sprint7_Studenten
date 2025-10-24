namespace Grocery.Core.Models
{
    public class Discount
    {
        public decimal DiscountPercentage { get; set; }
        public Product Product { get; set; }

        public Discount(Product product, decimal discountPercentage)
        {
            Product = product;
            DiscountPercentage = discountPercentage;
        }

        public void Apply()
        {
            Product.ApplyDiscount(DiscountPercentage);
        }

        public void Clear()
        {
            Product.ClearDiscount();
        }
    }
}
