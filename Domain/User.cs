using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser<Guid>
    {
        
        public ICollection<Opinion>? opinions { get; set;}
        public Guid? ReferrerId { get; set;} 
        public User? Referrer { get; set;} 
        public ICollection<User>? referres { get; set;}
        public UserInfo? UserInfo { get; set;}
        public string? Password { get; set;}
        public string? FirstName { get; set;}
        public string? LastName { get; set;}

    }


}

