namespace Shop.Application.Contract.Dtos
{
    public record KeyValueDto
    {
        public int Value { get; set; }
        public string Key { get; set; } = null!;
    }
}
