using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserSymptoms
    {
        public int Id { get; set; }
        public int UserInfoId { get; set; }
        public UserInfo userIndo { get; set; }
        public int SymptomId  { get; set; }
        public Symptoms SymptomsId  { get; set; }
    }
}
