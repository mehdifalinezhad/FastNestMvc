using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Sickness
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<UserInfo> userInfos { get; set; }    
       
    }
}
