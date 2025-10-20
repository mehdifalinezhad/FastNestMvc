using Application;
using Application.Dto;
using CommonJust;
using Domain;
using EndPoint.User.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EndPoint.User.Controllers
{
    public class FoodPlanController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.User> _userManager;

        public FoodPlanController(IUnitOfWork unitOfWork, UserManager<Domain.User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> FirstForm(string UserId="")
        {
            if (UserId == "")
            {
                TempData["ToastType"] = "warning";
                TempData["ToastMessage"] = "شما اول باید ثبت نام بعد لاگین کنید";
                return RedirectToAction("Index","Home");
            }
            var symsons = _unitOfWork.symptoms;
            var states = _unitOfWork.states;

            var AllSymptoms = await symsons.GetAllAsync();
            var AllStats = await states.GetAllAsync();
         
            await _unitOfWork.SaveChangesAsync();
            UserAnswerDto model = new UserAnswerDto()
            {
                states = AllStats.ToList(),
                Symsons = AllSymptoms.ToList(),
                RefferalsUser = _unitOfWork.GetUsers()
            };
           model.states.Insert(0, new State() { Id = 0, Name = "استان را قبل از شهر انتخاب کنید" });
           Domain.User thisUser = _unitOfWork.GetUserByUserId(UserId);
           model.LoginedUser= thisUser; 

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FirstForm(UserAnswerDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    var symsons = _unitOfWork.symptoms;
            //    var states = _unitOfWork.states;
            //    var AllSymptoms = await symsons.GetAllAsync();
            //    var AllStats = await states.GetAllAsync();
            //    dto.states = AllStats.ToList();
            //    dto.Symsons = AllSymptoms.ToList();
            //    dto.states.Insert(0, new State() { Id = 0, Name = "استان را قبل از شهر انتخاب کنید" });
            //    return View(dto);
            //}

            UserInfo userInfo = DtosToModels.UserAnswerToUserInfoModel(dto);
            ICollection<Symptoms> symptoms = _unitOfWork.SysmsonIdToSymsons(dto.SelectedSymptomIds);
            userInfo.Symptoms= symptoms;    
            var OrderAdded=_unitOfWork.userInfoAdd;
            
            var resultAdd=OrderAdded.AddAsync(userInfo);

            await _unitOfWork.SaveChangesAsync();
            var theUser = await _userManager.Users.Where(c => c.Id == dto.LoginedUser.Id).FirstOrDefaultAsync();
           theUser.ReferrerId=dto.RefferId;
           await _userManager.UpdateAsync(theUser);
            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "درج اطلاعات با موفقیت انجام شد";
            var states = _unitOfWork.states;
            var AllStats = await states.GetAllAsync();

            dto.states = AllStats.ToList();
            dto.states.Insert(0, new State() { Id = 0, Name = "استان را قبل از شهر انتخاب کنید" });
            dto.RefferalsUser = _unitOfWork.GetUsers();
            return View(dto);         
        }

      
       

        //this is for get city by State
        public ActionResult CallGetCitys(int thestateId)
        {
            var cityRepo = _unitOfWork.getCityRepository;
            List<City> cities = cityRepo.GetCitys(thestateId);
            return Json(cities);
        }




    }
}
