using Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class DashBoardDto
    {
        public DashBoardDto() 
        {
             foodplans = new List<Foodplan>();
             orders = new List<Orders>();
        }
        public int Id { get; set; } 
        public Guid UserId { get; set; }
        public User user { get; set; }
        public int FoodplanId { get; set; }
        public ICollection<Foodplan> foodplans {get; set;}
        public ICollection<Orders> orders {get; set;}
        public UserInfo userInfo { get; set; }
       
    }
}
