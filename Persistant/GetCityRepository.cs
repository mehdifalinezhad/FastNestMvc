using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using persistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistant
{
    public class GetCityRepository:IGetCityRepository
    {
        private readonly AppDbContext _context;
        private DbSet<City> DbCity;

        public GetCityRepository(AppDbContext context)
        {
            _context = context;
            DbCity = _context.Set<City>();
        }

        public List<City> GetCitys(int theStateId)
        {
            var cities = DbCity.Where(c => c.stateId == theStateId).ToList();
        
           return cities;
          
        }
    }
}
