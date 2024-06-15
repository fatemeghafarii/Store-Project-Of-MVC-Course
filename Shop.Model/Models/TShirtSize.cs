namespace Shop.Model.Models
{
    public class TShirtSize
    {
        public TShirtSize()
        {
            ProductTShirtSizes = new HashSet<ProductTShirtSize>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductTShirtSize> ProductTShirtSizes { get; set; }
    }


}
