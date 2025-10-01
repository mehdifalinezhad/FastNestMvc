using Application.Dto;
using Azure.Core.Extensions;
using Domain;
using EndPoint.User.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EndPoint.User.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Domain.User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<Domain.User> _signInManager;

        public UserController(UserManager<Domain.User> userManager, RoleManager<Role> roleManager, SignInManager<Domain.User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> StartDb()
        {
            var Role1 = new Role()
            {
                Name = "Admin"
            };
            await _roleManager.CreateAsync(Role1);
            var Role2 = new Role()
            {
                Name = "Customer"
            };
            await _roleManager.CreateAsync(Role2);
            return View();
        }
        public IActionResult Login()
        {
            return View(new LoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }
            var theUser=await _userManager.FindByNameAsync(loginDto.UserName);
            if (theUser == null)
            {

                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "شما اول باید ثبت نام کنید ";
                return View(loginDto);

            }
            var checkPass = await _signInManager.PasswordSignInAsync(theUser,loginDto.Password,true,true);
            if (!checkPass.Succeeded)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "رمز اشتباه است";
                return View(loginDto);
            }
            HttpContext.Session.SetString("ActiveUser", theUser.Id.ToString());

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "ورود با موفقیت انجام شد";
            return RedirectToAction("Index","Home");


              

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Remove("UserId");
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            Domain.User userToAdd = DtosToModels.AddUserDtoToModel(userDto);

            var result = await _userManager.CreateAsync(userToAdd, userToAdd.Password);
            var AddedRole = await _userManager.AddToRoleAsync(userToAdd, "Customer");
            //notishow.Add("مثلا ثبت نام شما با موفقیت انجام شد"); 
            //این رو واس بنویسم یا نه؟
            return View(userDto);

        }


       
    }
}
