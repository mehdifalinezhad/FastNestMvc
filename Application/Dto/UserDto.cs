
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "نام الزامی است")]
        public string FirstName { set; get; }
        [Required(ErrorMessage = "نام خانوادگی الزامی است ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "نام کاربری الزامی است ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "شماره موبایل الزامی است")]
       // [RegularExpression(@"^09\d{9}$", ErrorMessage = "فرمت شماره موبایل معتبر نیست")]
        public string PhoneNumber { get; set;}
        [Required(ErrorMessage = "ایمیل الزامی است")]
        //[EmailAddress(ErrorMessage = "فرمت ایمیل معتبر نیست")]
        public string Email { get; set;}
        [Required(ErrorMessage = "ورود رمز عبور اجباری است ")]
        public string Password { get; set;}
        [Required(ErrorMessage = "ورود  تکرار رمز عبور اجباری است ")]
        [Compare("Password", ErrorMessage = "تکرار رمز عبور باید شبیه رمز عبور باشد")]
        public string ComfirmPassword { get; set;}
        public string? Role { get; set;}
        
        
    }
}
