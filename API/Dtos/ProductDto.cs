namespace API.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; } = default!;
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}