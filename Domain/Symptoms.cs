namespace Domain
{
   public class Symptoms
   {
        public int Id { get; set; }
        public string? Description { get; set; }
        public ICollection<UserInfo> userInfos { get; set; }
    }
}
