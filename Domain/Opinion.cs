namespace Domain
{
    public class Opinion
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? insertTime{ get; set; }
        public Guid? userId { get; set; }
        public User? user { get; set; }
       
    }
}
