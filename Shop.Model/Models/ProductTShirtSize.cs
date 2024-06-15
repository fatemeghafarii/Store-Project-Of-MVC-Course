namespace Shop.Model.Models
{
    public class ProductTShirtSize
    {
        public int Id { get; set; }
        public int TShirtSizeId { get; set; }
        public TShirtSize TShirtSize { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }


}
