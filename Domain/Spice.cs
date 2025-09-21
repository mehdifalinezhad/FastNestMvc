using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Spice
    {
        public int Id { get; set; }
        public int name { get; set; }
        public int FoodPlanId { get; set; }  
        public Foodplan foodPlan { get; set; }  
    }
}
