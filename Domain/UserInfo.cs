
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

using System.Threading;

namespace Domain
{
    public class UserInfo
    {
       public int Id { get; set;} 
        [ForeignKey("User")]
        public Guid UserId { get; set;} //به دلیل رابطه یک به یک میباشد   یک به چند نمیخواد.
        public User? user { get; set;}
        public int? AbdominalRound { get; set; }
        public int? ArmRound { get; set; }
        public int? ThighRound { get; set; }
        public int? LegRound { get; set; }
        public int? AssRound { get; set; }
        public string? ImageUrls { get; set;}
        public Gender gender { get; set; }
        public Marrige marrige { get; set; }
        public string? EaveningMeal { get; set;}
        public string? LastMeal { get; set;}
        public string? Job { get; set;}
        public string? FavoritFood { get; set;}
        //اقدامات لاغری
        public string? ActionSkiny { get; set;}
        public string? DailyActivity { get; set;}
        //public int cityId { get; set;}
        public City? city { get; set;}
        public ICollection<Symptoms> Symsoms {get; set;}    
        public ICollection<Sickness> sicKness {get; set;}    
        public ICollection<Medicines> medicins{get; set;}    
    }
} 
