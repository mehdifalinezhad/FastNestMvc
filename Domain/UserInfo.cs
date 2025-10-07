
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
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
        public string? ImageUrls { get; set;}
        public Gender gender { get; set; }
        public Marrige marrige { get; set; }
        public string? LastMeal { get; set;}
        public string? FavoritFood { get; set;}
        //اقدامات لاغری
        public string? ActionSkiny { get; set;}
        public int CityId { get; set;}
        public City? city { get; set;}
        public ICollection<Symptoms> Symsoms {get; set;}    
        public ICollection<Sickness> sicKness {get; set;}    
        public ICollection<Medicines> medicins{get; set;}
        public decimal? AbdominalRound { get; set; }
        public decimal? ArmRound { get; set; }
        public decimal? ThighRound { get; set; }
        public decimal? LegRound { get; set; }
        public decimal? AssRound { get; set; }
        public List<string> ImageFiles { get; set; }
        public bool? Deal { get; set; }
        //public bool HairLose { get; set;}  ====>this for symsone
        public int? wakeTime { get; set; }
        public int? SleepTime { get; set; }
        public string? BreakfastMeal { get; set; }
        public string? morningBetweenMeal { get; set; }
        public string? LaunchMeal { get; set; }
        public string? LaunchTime { get; set; }
        public string? dinnerMeal { get; set; }
        public string? dinnerTime { get; set; }
        public string? EaveningMeal { get; set; }
        public string? Job { get; set; }
        //اقدامات لاغری
        public string? DailyActivity { get; set; }
       // public string SelectedSymptomIds { get; set; }
        public string BirthDay { get; set; }
        public string registerDate { get; set; }
      //  public List<City> cites { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "لطفاً یک استان انتخاب کنید")]
        //public int StateId { get; set; }
     //   public int CityId { get; set; }

       //ublic List<State> states { get; set; }
        public string? Historysickness { get; set; }
        public int? age { get; set; }
        public int? height { get; set; }
        public int? weight { get; set; }
        //or must be forignKey
        public string? dislikeFood { get; set; }
        public string? medicineUse { get; set; }
        public string? favoriteFood { get; set; }
        public string? ReferralName { get; set; }
        public string? DurationUsed { get; set; }
    }
} 
