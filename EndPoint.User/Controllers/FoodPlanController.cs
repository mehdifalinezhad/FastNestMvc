using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.User.Controllers
{
    public class FoodPlanController : Controller
    {
        public IActionResult FirstForm()
        {
             
            return View();
        }
        [HttpPost]
        public IActionResult FirstForm(FirstFormDto dto)
        {


            return View();
        }
    }
}
