using Application;
using Application.Dto;
using Domain;
using EndPoint.User.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EndPoint.User.Controllers
{

    public class DashboardController : Controller
    {
        private readonly UserManager<Domain.User> _userManager;
        private IUnitOfWork unitOfWork;
        public DashboardController(UserManager<Domain.User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult DashboardIndex(string UserId)
        {

            Domain.User DashUser = _userManager.Users.FirstOrDefault(c => c.Id.ToString() == UserId);
            var theUserInfo = unitOfWork.userInfo;
             UserInfo userInfoDash= theUserInfo.GetUserInfo(UserId);
           DashBoardDto dashBoardDto = ModelsToDtos.UserUserInfoModelToDashboadDto(DashUser,userInfoDash);
            

            unitOfWork.SaveChangesAsync();

            return View(dashBoardDto);
        }
    
    
       
    
    }
}
