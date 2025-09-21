using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class State
    {
        public int Id { get; set; }
        public int Name {get; set;}
        public ICollection<City> cites { get; set; }
    }
}
