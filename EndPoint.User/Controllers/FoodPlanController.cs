using Application;
using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

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
        public  IActionResult FirstForm(UserAnswerDto dto)
        {
            if (!ModelState.IsValid)
            {

            

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
