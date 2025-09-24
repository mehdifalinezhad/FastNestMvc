
namespace Domain
{
    public  class Foodplan
    {
        public int Id { get; set; }
      //  public Orders? order { get; set;}
        public Guid? UserId { get; set; }
        public User? User { get; set;}
        public DateTime ExpirationDate { get; set;}
        public int? DuratioTImeMeal { get; set;}

      //  public int CategoryFoodPlanId { get; set; }
        public CategoryFoodPlan CategoryFoodPlan { get; set; }
        public ICollection<OrderItems> orderItems { get; set; }
        
        public ICollection<Vitamins> vitamins { get; set; }
        public ICollection<Spice> spices { get; set; }
        public ICollection<Food> foods { get; set; }
   
        public ICollection<Symptoms> Symptoms { get; set; }  
    }
}