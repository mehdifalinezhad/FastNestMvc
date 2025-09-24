using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderItems
    {
        public int Id { get; set; } 
       // public int OrderId { get; set; }
        public Orders? order { get; set; }
     //   public int FoodplanId { get; set; }
        public Foodplan? foodplan { get; set;}
        public int Count { get; set;}
      
    
    }
}
