using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Food
    {
        public int Id{ get; set; }
        public string name{ get; set; }
        //public int FoodPlanId{ get; set; }
        public Foodplan foodplan{ get; set; }
        
    
    }
}
