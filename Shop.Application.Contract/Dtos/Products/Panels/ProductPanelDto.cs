namespace Shop.Application.Contract.Dtos.Products.Panels
{
    public record ProductPanelDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
