namespace Domain
{
    public class CategoryFoodPlan
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public ICollection<Foodplan>? foodplans { get; set; }
    }
}
