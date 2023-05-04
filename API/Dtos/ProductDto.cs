namespace API.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = default!;
        public int Stock { get; set; }
        public float Price { get; set; }
    }
    public class ProductListDto
    {
        public string Name { get; set; } = default!;
        public int Stock { get; set; }
        public Int64 Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}