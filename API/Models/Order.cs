using API.Models.common;

namespace API.Models
{
    public class Order : BaseModel
    {
        public int CustomerId { get; set; }
        public string Desscription { get; set; } = default!;
        public string Address { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = default!;
        public ICollection<Customer> Customers { get; set; } = default!;
    }
}