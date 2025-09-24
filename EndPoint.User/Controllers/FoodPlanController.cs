using Application;
using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> FirstForm(UserAnswerDto dto)
        {

            
            return View();
        
        
        }
    }
}
