using Application;
using Application.Dto;
using CommonJust;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using Persistant;
using System.Runtime.Intrinsics.Arm;


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

        public async Task<IActionResult> FirstForm(int UserId=0)
        {
            if (UserId == 0)
            {

                TempData["ToastType"] = "success";
                TempData["ToastMessage"] = "ثبت نام با موفقیت انجام شذ";
                return RedirectToAction("Index","Home");

            }
            var symsons = _unitOfWork.symptoms;
            var states = _unitOfWork.states;
            var AllSymptoms = await symsons.GetAllAsync();
            var AllStats = await states.GetAllAsync();
            _unitOfWork.SaveChangesAsync();
            UserAnswerDto model = new UserAnswerDto()
            {
                states = AllStats.ToList(),
                Symsons = AllSymptoms.ToList()
            };
            model.states.Insert(0, new State() { Id = 0, Name = "استان را قبل از شهر انتخاب کنید" });
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FirstForm(UserAnswerDto dto)
        {
            if (!ModelState.IsValid)
            {

                var symsons = _unitOfWork.symptoms;
                var states = _unitOfWork.states;
                var AllSymptoms = await symsons.GetAllAsync();
                var AllStats = await states.GetAllAsync();
                dto.states = AllStats.ToList();
                dto.Symsons = AllSymptoms.ToList();
                dto.states.Insert(0, new State() { Id = 0, Name = "استان را قبل از شهر انتخاب کنید" });

                return View(dto);
            }

            UserInfo userInfo = new UserInfo()
            {
                ArmRound = dto.ArmRound,
                ActionSkiny = dto.ActionSkiny,
                DailyActivity = dto.DailyActivity,
                LastMeal = dto.LastMeal,
                LaunchMeal = dto.LaunchMeal,
                marrige = dto.married,
                gender = dto.gender,
                height = dto.height,
                Job = dto.Job,
                Historysickness = dto.Historysickness,
                AbdominalRound = dto.AbdominalRound,
                AssRound = dto.AssRound,
                wakeTime = dto.wakeTime,
                weight = dto.weight,
                age = dto.age,
                BreakfastMeal = dto.BreakfastMeal,
                //this how know to insert
                //  sicKness=dto.Historysickness,
                DurationUsed = dto.DurationUsed,
                registerDate = dto.registerDate,
                dislikeFood = dto.dislikeFood,
                EaveningMeal = dto.EaveningMeal,
                favoriteFood = dto.favoriteFood,
                LegRound = dto.LegRound,
                LaunchTime = dto.LaunchTime,
                BirthDay = dto.BirthDay,
                Deal = dto.Deal,
                //StateId = dto.StateId,
                dinnerMeal = dto.dinnerMeal,
                medicineUse = dto.medicineUse,
                morningBetweenMeal = dto.morningBetweenMeal,
                SleepTime = dto.SleepTime,
                ThighRound = dto.ThighRound,
                ImageUrls = HimImageUrls(dto.ImageFiles, dto.LastName),
                UserId = dto.UserId,
                dinnerTime=dto.dinnerTime,
                CityId = dto.CityId,
            
            };

            var OrderAdded=_unitOfWork.userInfoAdd;
            var resultAdd=OrderAdded.AddAsync(userInfo);

            _unitOfWork.SaveChangesAsync();
            var theUser = await _userManager.Users.Where(c => c.Id == dto.UserId).FirstOrDefaultAsync();
            if (theUser != null)
            {
                theUser.ReferrerId = dto.RefferId;
                var resultReffer = _userManager.UpdateAsync(theUser);

            }
            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "ثبت نام با موفقیت انجام شذ";
            return View(dto);         
        }

        private string HimImageUrls(List<IFormFile> files, string LastNAme)
        {
            var urls=new List<string>();
            foreach (var item in files)
            {
               urls.Add(UploadImages.SaveImage(item,LastNAme));
            }
            string strings =string.Join(",",urls);
            //List<string> ass= strings.Split(",").ToList();
            return strings;
        
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
