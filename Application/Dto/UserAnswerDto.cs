using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UserAnswerDto
    {
        [Required(ErrorMessage = "نام الزامی است")]
        public string FirstName { set; get; }
        [Required(ErrorMessage = "نام خانوادگی الزامی است ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است ")]
        public string FullName{ get; set; }
   

        [Required(ErrorMessage = "شماره موبایل الزامی است")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "فرمت شماره موبایل معتبر نیست")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل معتبر نیست")]
        public string Email { get; set; }
        public int? AbdominalRound { get; set; }
        public int? ArmRound { get; set; }
        public int? ThighRound { get; set; }
        public int? LegRound { get; set; }
        public int? AssRound { get; set; }
        public string? ImageUrls { get; set; }
        public int? married { get; set; }
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
        public string? LastMeal { get; set; }
        public string? Job { get; set; }
        //اقدامات لاغری
        public string? ActionSkiny { get; set; }
        public string? DailyActivity { get; set; }
        public ICollection<Symptoms> Symsons { get; set; }
        public List<int> SelectedSymptomIds { get; set; }   
        public string BirthDay { get; set; }
        public string registerDate { get; set; }
        public int Gender { get; set; }
        public ICollection<City> cites { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public ICollection<State> states { get; set; }
        public string? Historysickness { get; set; }
        public int? age { get; set;}
        public int? height { get; set; }
        public int? weight { get; set; }
        public string? dislikeFood { get; set; }
        public string? medicineUse { get; set; }
        public string? favoriteFood { get; set; }
        
        
        
        public UserAnswerDto()
        {
            cites = new List<City>();

        }

    }
}
