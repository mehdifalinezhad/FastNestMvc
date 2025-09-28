using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("State")]
        public int stateId { get; set; }
        public State state { get; set; }
    }
}
