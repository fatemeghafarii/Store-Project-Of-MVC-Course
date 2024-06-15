namespace Shop.Application.Contract.Dtos.Products
{
    public record ProductDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sizes { get; set; }

        private string viewImagePath = "";
        public string ViewImagePath
        {
            get { return Path.Combine(Images.HttpImagePath, viewImagePath); }

        }

        public string ImagePath
        {
            get
            {
                return viewImagePath;
            }
            set { viewImagePath = value; }
        }
    }
}
