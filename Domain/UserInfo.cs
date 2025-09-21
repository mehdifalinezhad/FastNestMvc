namespace Domain
{
    public class UserInfo
    {
        public int Id { get; set;} 
        public Guid UserId { get; set;} 
        public User? user { get; set;}
        public int? AbdominalRound { get; set; }
        public int? ArmRound { get; set; }
        public int? ThighRound { get; set; }
        public int? LegRound { get; set; }
        public int? AssRound { get; set; }
        public string? ImageUrls { get; set;}
        public bool? married { get; set;}
        public bool? Deal { get; set;}
        //public bool HairLose { get; set;}  ====>this for symsone
        public int?  wakeTime { get; set;}
        public int? SleepTime { get; set;}
        public string? BreakfastMeal { get; set;}
        public string? LaunchMeal { get; set;}
        public string? LaunchTime { get; set;}
        public string? dinnerMeal { get; set;}
        public string? dinnerTime { get; set;}
        public string? EaveningMeal { get; set;}
        public string? LastMeal { get; set;}
        public string? Job { get; set;}
        //اقدامات لاغری
        public string? ActionSkiny { get; set;}
        public string? DailyActivity { get; set;}
        public int cityId { get; set;}
        public City? city { get; set;}
        public ICollection<UserSymptoms> UserSymsons {get; set;}    
    }
} 
