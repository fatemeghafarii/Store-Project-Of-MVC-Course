namespace Shop.Model.Models
{
    public class Product
    {
        public Product()
        {
            ProductTShirtSizes = new HashSet<ProductTShirtSize>();
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public ICollection<ProductTShirtSize> ProductTShirtSizes { get; set; }
    }
}
