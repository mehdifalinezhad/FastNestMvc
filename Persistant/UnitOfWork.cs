using Application;
using Domain;
using persistant;
namespace Persistant
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Foodplan> footPlans { get; set;}

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            footPlans = new GenericRepository<Foodplan>(_context);
        }
        public async Task<int> SaveChangesAsync()
        {
            return _context.SaveChanges(); ;
        }






    }
}
