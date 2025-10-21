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
        private IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult DashboardIndex(string UserId="")
        {
            //       if (UserId == "")
            //       {
            //           TempData["ToastType"] = "warning";
            //           TempData["ToastMessage"] = "شما اول باید ثبت نام بعد لاگین کنید";
            //           return RedirectToAction("Index", "Home");
            //       }

            var Test=_unitOfWork.GetUserAndUserInfo(UserId);
            return View(new DashBoardDto());
        }
    
    
       
    
    }
}
