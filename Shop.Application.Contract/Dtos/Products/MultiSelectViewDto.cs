namespace Shop.Application.Contract.Dtos.Products
{
    public record MultiSelectViewDto
    {
        public MultiSelectViewDto()
        {

            KeyValues = new List<KeyValueDto>();
            SelectedCheckBoxes = new List<int>();
        }
        public List<KeyValueDto> KeyValues { get; set; }
        public ICollection<int> SelectedCheckBoxes { get; set; }
    }
}
