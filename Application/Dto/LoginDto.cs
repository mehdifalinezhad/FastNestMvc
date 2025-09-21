

using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage= "وارد کردن نام کاربری اجباری است")]
        public string UserName { get; set; }
        [Required(ErrorMessage =" وارد کردن رمز عبور اجباری است")]
        public string Password{ get; set; }
      
    }
}
