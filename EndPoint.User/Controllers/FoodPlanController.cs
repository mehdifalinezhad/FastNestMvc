using Application;
using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace EndPoint.User.Controllers
{
    public class FoodPlanController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public FoodPlanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> FirstForm()
        {
            var symsons =_unitOfWork.symptoms;
            var states = _unitOfWork.states;
            var AllSymptoms= await symsons.GetAllAsync();
            var AllStats = await states.GetAllAsync();
            UserAnswerDto model = new UserAnswerDto()
            {
                states = AllStats.ToList(),
                Symsons= AllSymptoms.ToList()
            };
            model.states.Insert(0,new State() {Id=0,Name="استان را قبل از شهر انتخاب کنید" });
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
            
            return View();
        }

        public ActionResult CallGetCitys(int thestateId)
        {
            var cityRepo=_unitOfWork.getCityRepository;
            List<City> cities = cityRepo.GetCitys(thestateId);
            return Json(cities);
        }




    }
}
