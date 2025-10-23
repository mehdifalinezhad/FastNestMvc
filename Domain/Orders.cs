

namespace Domain
{
    public class Orders
    {
        public int Id { get; set; }
       // public Guid UserId { get; set; }    
        public UserInfo userInfo { get; set; }

        public ICollection<OrderItems> orderItems { get; set; }    
        public decimal TotalPrise { get; set; }   

    }
}
