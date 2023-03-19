namespace API.Models.common
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        virtual public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}