

namespace Domain
{
    public class Orders
    {
        public int Id { get; set; }
       // public Guid UserId { get; set; }    
        public User user { get; set; }
        public ICollection<OrderItems> orderItems { get; set; }    
        public decimal TotalPrise { get; set; }   

    }
}
