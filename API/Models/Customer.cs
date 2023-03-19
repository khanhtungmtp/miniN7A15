using API.Models.common;

namespace API.Models
{
    public class Customer : BaseModel
    {
        public string Name { get; set; } = default!;
        public ICollection<Order> Orders { get; set; } = default!;
    }
}