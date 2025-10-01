using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Application.Dto
{
    public class UserAnswerDto
    {
        [Required(ErrorMessage = "نام الزامی است")]
        public string? FirstName { set; get; }
        [Required(ErrorMessage = "نام خانوادگی الزامی است ")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است ")]
        public string? FullName{ get; set; }
        [Required(ErrorMessage = "شماره موبایل الزامی است")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "فرمت شماره موبایل معتبر نیست")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل معتبر نیست")]
        public string? Email { get; set; }
        public decimal? AbdominalRound { get; set; }
        public decimal? ArmRound { get; set; }
        public decimal? ThighRound { get; set; }
        public decimal? LegRound { get; set; }
        public decimal? AssRound { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public bool? Deal { get; set; }
        //public bool HairLose { get; set;}  ====>this for symsone
        public int? wakeTime { get; set; }
        public int? SleepTime { get; set; }
        public string? BreakfastMeal { get; set;}
        public string? morningBetweenMeal {get;set;}
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
        public Domain.Enums.Gender gender { get; set; }
        public Domain.Enums.Marrige married { get; set; }
        public List<City> cites { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "لطفاً یک استان انتخاب کنید")]
        public int StateId { get; set; }
        public int CityId { get; set; }

        public List<State> states { get; set; }
        public string? Historysickness { get; set; }
        public int? age { get; set;}
        public int? height { get; set; }
        public int? weight { get; set; }
        //or must be forignKey
        public string? dislikeFood { get; set; }
        public string? medicineUse { get; set; }
        public string? favoriteFood { get; set; }
        public string? ReferralName { get; set; }
        public Guid userId { get; set; }
        public string? DurationUsed { get; set; }
        public UserAnswerDto()
        {
            cites = new List<City>();
            //gender = Domain.Enums.Gender.male;
            //married = Domain.Enums.Marrige.single;
        }

    }
}
