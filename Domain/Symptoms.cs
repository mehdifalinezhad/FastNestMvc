namespace Domain
{
   public class Symptoms
   {
        public int Id { get; set; }
        public string? Discription { get; set; }
        public ICollection<UserSymptoms> userSymptoms { get; set; }



    }
}
