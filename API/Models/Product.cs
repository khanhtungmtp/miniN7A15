using API.Models.common;

namespace API.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = default!;
        public int Stock { get; set; }
        public Int64 Price { get; set; }
        public ICollection<Order> Orders { get; set; } = default!;
    }
}